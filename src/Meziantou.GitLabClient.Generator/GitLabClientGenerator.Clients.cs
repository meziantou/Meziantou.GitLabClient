using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using Meziantou.Framework;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class GitLabClientGenerator
    {
        private void GenerateClients(Project project)
        {
            foreach (var methodGroup in project.MethodGroups)
            {
                GenerateClient(methodGroup);
            }
        }

        private void GenerateClient(MethodGroup methodGroup)
        {
            var groupUnit = CreateUnit("GitLabClient." + methodGroup.Name + ".cs");
            var groupNs = groupUnit.AddNamespace(RootNamespace);

            var clientInterface = groupNs.AddType(new InterfaceDeclaration("IGitLabClient") { Modifiers = Modifiers.Public | Modifiers.Partial });
            var groupClientInterface = groupNs.AddType(new InterfaceDeclaration("IGitLab" + methodGroup.Name + "Client") { Modifiers = Modifiers.Public | Modifiers.Partial });

            var groupClientClass = groupNs.AddType(new ClassDeclaration("GitLabClient")
            {
                Modifiers = Modifiers.Partial | Modifiers.Public,
                Implements = { groupClientInterface },
            });

            // Property
            clientInterface.AddMember(new PropertyDeclaration(methodGroup.Name, groupClientInterface)
            {
                Getter = new PropertyAccessorDeclaration() { Statements = null },
            });

            groupClientClass.AddMember(new PropertyDeclaration(methodGroup.Name, groupClientInterface)
            {
                Modifiers = Modifiers.Public,
                Getter = new PropertyAccessorDeclaration()
                {
                    Statements = { new ReturnStatement(new ThisExpression()) },
                },
            });

            // Extension methods
            var clientExtensionsClass = groupNs.AddType(new ClassDeclaration("GitLabClientExtensions")
            {
                Modifiers = Modifiers.Partial | Modifiers.Public | Modifiers.Static,
            });

            // Methods
            foreach (var method in methodGroup.Methods)
            {
                var requestType = CreateMethodArgumentType(groupNs, method);
                GenerateInterfaceMethod(groupClientInterface, method, requestType);
                GenerateExplicitImplementationMethod(groupClientClass, groupClientInterface, method, requestType);
                GenerateMethod(groupClientClass, method, requestType);
                GenerateMandatoryParameterExtensions(clientExtensionsClass, method, groupClientInterface, requestType);
            }

            if (clientExtensionsClass.Members.Count == 0)
            {
                groupNs.Types.Remove(clientExtensionsClass);
            }
        }

        private static MethodDeclaration GenerateInterfaceMethod(InterfaceDeclaration clientInterface, Method method, TypeReference requestType)
        {
            var m = clientInterface.AddMember(new MethodDeclaration(GetMethodName(method)));
            GenerateMethodSignature(method, m, requestType, out _, out _, out _);
            return m;
        }

        private static string GetMethodName(Method method)
        {
            var result = method.Name;
            if (method.MethodType != MethodType.GetPaged)
            {
                result += "Async";
            }

            return result;
        }

        private static MethodDeclaration GenerateExplicitImplementationMethod(ClassDeclaration clientClass, InterfaceDeclaration clientInterface, Method method, TypeReference requestType)
        {
            var m = clientClass.AddMember(new MethodDeclaration(GetMethodName(method)));
            m.PrivateImplementationType = clientInterface;
            GenerateMethodSignature(method, m, requestType, out _, out _, out _);
            foreach (var arg in m.Arguments)
            {
                arg.DefaultValue = null;
            }

            m.Statements = new ReturnStatement(
                new MethodInvokeExpression(
                    new MemberReferenceExpression(new ThisExpression(), method.MethodGroup.Name + '_' + m.Name),
                    m.Arguments.Select(arg => new ArgumentReferenceExpression(arg)).ToArray()));
            return m;
        }

        private static MethodDeclaration GenerateBuildUrlMethod(ClassDeclaration clientClass, Method method, TypeReference requestType)
        {
            var m = clientClass.AddMember(new MethodDeclaration(method.MethodGroup.Name + '_' + GetMethodName(method) + "_BuildUrl"));
            m.Modifiers = Modifiers.Private | Modifiers.Static;
            m.ReturnType = typeof(string);

            // Method body
            m.Statements = new StatementCollection();

            var urlVariable = new VariableDeclarationStatement(typeof(string), "url");
            m.Statements.Add(urlVariable);

            // 1. Create url from parameters
            var parameters = method.Parameters.Where(p => GetParameterLocation(method, p) == ParameterLocation.Url).ToList();
            if (parameters.Any())
            {
                var requestArgument = m.AddArgument("request", requestType);

                // [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
                m.CustomAttributes.Add(new CustomAttribute(typeof(SuppressMessageAttribute))
                {
                    Arguments =
                    {
                        new CustomAttributeArgument(new LiteralExpression("Reliability")),
                        new CustomAttributeArgument(new LiteralExpression("CA2000:Dispose objects before losing scope")),
                        new CustomAttributeArgument("Justification", new LiteralExpression("The rule doesn't understand ref struct")),
                    },
                });

                var segments = GetSegments(method.UrlTemplate);
                var urlBuilder = new VariableDeclarationStatement(
                    WellKnownTypes.UrlBuilderTypeReference, "urlBuilder",
                    new NewObjectExpression(WellKnownTypes.UrlBuilderTypeReference));
                var urlUsingStatement = new UsingStatement()
                {
                    Statement = urlBuilder,
                    Body = new StatementCollection(),
                };
                var usingStatements = urlUsingStatement.Body;
                m.Statements.Add(urlUsingStatement);

                foreach (var segment in segments)
                {
                    if (segment[0] == ':')
                    {
                        var param = parameters.SingleOrDefault(p => p.Name == segment[1..]);
                        if (param == null)
                            throw new InvalidOperationException($"Parameter '{segment}' is not mapped for method '{method.UrlTemplate}'");

                        AddParameter(param, separator: null, encoded: true);
                        parameters.Remove(param);
                    }
                    else if (segment[0] == '*')
                    {
                        var param = parameters.SingleOrDefault(p => p.Name == segment[1..]);
                        if (param == null)
                            throw new InvalidOperationException($"Parameter '{segment}' is not mapped for method '{method.UrlTemplate}'");

                        AddParameter(param, separator: null, encoded: false);
                        parameters.Remove(param);
                    }
                    else if (segment.StartsWith("[.", StringComparison.Ordinal))
                    {
                        var param = parameters.SingleOrDefault(p => p.Name == segment[2..^1]);
                        if (param == null)
                            throw new InvalidOperationException($"Parameter '{segment}' is not mapped for method '{method.UrlTemplate}'");

                        AddParameter(param, separator: null, encoded: false, prefix: ".");
                        parameters.Remove(param);
                    }
                    else
                    {
                        usingStatements.Add(urlBuilder.CreateInvokeMethodExpression("Append", new LiteralExpression(segment)));
                    }
                }

                if (parameters.Any())
                {
                    var separator = new VariableDeclarationStatement(typeof(char), "separator", new LiteralExpression('?'));
                    usingStatements.Add(separator);

                    foreach (var param in parameters)
                    {
                        AddParameter(param, separator, encoded: true);
                    }
                }

                usingStatements.Add(new AssignStatement(urlVariable, urlBuilder.CreateInvokeMethodExpression("ToString")));

                void AddParameter(MethodParameter param, VariableDeclarationStatement separator, bool encoded, string prefix = null)
                {
                    var appendParameterMethodName = encoded ? "AppendParameter" : "AppendRawParameter";

                    void AddSeparator(StatementCollection statements)
                    {
                        if (separator != null)
                        {
                            statements.Add(urlBuilder.CreateInvokeMethodExpression("Append", separator));
                            statements.Add(new AssignStatement(separator, new LiteralExpression('&')));
                            statements.Add(urlBuilder.CreateInvokeMethodExpression("Append", new LiteralExpression(param.Name + '=')));
                        }
                    }

                    void AppendPrefix(StatementCollection statements)
                    {
                        if (!string.IsNullOrEmpty(prefix))
                        {
                            statements.Add(urlBuilder.CreateInvokeMethodExpression("Append", prefix));
                        }
                    }

                    if (param.Type.IsParameterEntity)
                    {
                        var propertyName = param.Type.ParameterEntity.FinalType == ModelRef.Object ? "ValueAsString" : "Value";
                        var hasValueCondition = new ConditionStatement
                        {
                            Condition = CreatePropertyReference().CreateMemberReferenceExpression(nameof(Nullable<int>.HasValue)),
                            TrueStatements = new StatementCollection(),
                        };

                        AddSeparator(hasValueCondition.TrueStatements);
                        AppendPrefix(hasValueCondition.TrueStatements);
                        hasValueCondition.TrueStatements.Add(urlBuilder
                                .CreateInvokeMethodExpression(
                                    appendParameterMethodName,
                                    FormatValue(param.Type, CreatePropertyReference().CreateInvokeMethodExpression("GetValueOrDefault").CreateMemberReferenceExpression(propertyName))));

                        urlUsingStatement.Body.Add(hasValueCondition);
                    }
                    else
                    {
                        var isValueType = param.Type.IsValueType && !param.Type.IsCollection;

                        var hasValueCondition = new ConditionStatement
                        {
                            Condition = isValueType ? CreatePropertyReference().CreateMemberReferenceExpression("HasValue") :
                                                      new UnaryExpression(UnaryOperator.Not,
                                                         new MethodInvokeExpression(
                                                             new MemberReferenceExpression(new TypeReference(typeof(object)), "ReferenceEquals"),
                                                             CreatePropertyReference(), LiteralExpression.Null())),
                            TrueStatements = new StatementCollection(),
                        };

                        AddSeparator(hasValueCondition.TrueStatements);
                        AppendPrefix(hasValueCondition.TrueStatements);

                        Expression value = isValueType ? CreatePropertyReference().CreateInvokeMethodExpression("GetValueOrDefault") : CreatePropertyReference();
                        var appendMethod = new MethodInvokeExpression(
                            new MemberReferenceExpression(urlBuilder, appendParameterMethodName),
                                FormatValue(param.Type, value));

                        hasValueCondition.TrueStatements.Add(appendMethod);
                        urlUsingStatement.Body.Add(hasValueCondition);
                    }

                    MemberReferenceExpression CreatePropertyReference()
                    {
                        return requestArgument.CreateMemberReferenceExpression(ToPropertyName(param.Name));
                    }
                }
            }
            else
            {
                m.Statements.Add(new AssignStatement(urlVariable, new LiteralExpression(method.UrlTemplate)));
            }

            m.Statements.Add(new ReturnStatement(urlVariable));
            return m;
        }

        private static MethodDeclaration GenerateMethod(ClassDeclaration clientClass, Method method, TypeReference requestType)
        {
            var m = clientClass.AddMember(new MethodDeclaration(method.MethodGroup.Name + '_' + GetMethodName(method)));
            m.SetData("Method", method);
            var buildUrlMethod = GenerateBuildUrlMethod(clientClass, method, requestType);
            GenerateMethodSignature(method, m, requestType, out var requestArgument, out var requestOptionsArgument, out var cancellationTokenArgument);
            m.Modifiers = Modifiers.Private;
            if (method.MethodType != MethodType.GetPaged)
            {
                m.Modifiers |= Modifiers.Async;
            }

            // Method body
            m.Statements = new StatementCollection();

            // 1. Create url from parameters
            var buildUrlExpression = new MethodInvokeExpression(new MemberReferenceExpression(new TypeReference(clientClass), buildUrlMethod));
            if (buildUrlMethod.Arguments.Count > 0)
            {
                buildUrlExpression.Arguments.Add(requestArgument);
            }

            var urlVariable = new VariableDeclarationStatement(typeof(string), "url", buildUrlExpression);
            m.Statements.Add(urlVariable);

            if (method.MethodType == MethodType.GetPaged)
            {
                // return new Meziantou.GitLab.PagedResponse<MergeRequest>(this, url, requestOptions);
                m.Statements.Add(new ReturnStatement(new NewObjectExpression(m.ReturnType!.Clone(), new ThisExpression(), urlVariable, requestOptionsArgument)));
            }
            else
            {
                // 2. Create HttpRequestMessage object
                var requestVariable = new VariableDeclarationStatement(typeof(HttpRequestMessage), "requestMessage", new NewObjectExpression(typeof(HttpRequestMessage)));
                var usingStatement = new UsingStatement() { Statement = requestVariable, Body = new StatementCollection() };
                m.Statements.Add(usingStatement);
                var statements = usingStatement.Body;

                statements.Add(new AssignStatement(new MemberReferenceExpression(requestVariable, nameof(HttpRequestMessage.Method)), GetHttpMethod(method.MethodType)));
                statements.Add(new AssignStatement(new MemberReferenceExpression(requestVariable, nameof(HttpRequestMessage.RequestUri)), new NewObjectExpression(typeof(Uri), urlVariable, new MemberReferenceExpression(typeof(UriKind), nameof(UriKind.RelativeOrAbsolute)))));

                CreateBodyArgument(method, statements, requestArgument, requestVariable);

                // 3. Send request
                // var response = await SendAsync(request, options, cancellationToken).ConfigureAwait(false);
                var responseVariable = new VariableDeclarationStatement(WellKnownTypes.HttpResponseTypeReference.MakeNullable(), "response", LiteralExpression.Null());
                statements.Add(responseVariable);
                var responseTry = new TryCatchFinallyStatement() { Try = new StatementCollection() };
                statements.Add(responseTry);
                responseTry.Try.Add(new AssignStatement(responseVariable, new AwaitExpression(new MethodInvokeExpression(new MemberReferenceExpression(new ThisExpression(), "SendAsync"), requestVariable, requestOptionsArgument, cancellationTokenArgument)).ConfigureAwait(false)));

                // Dispose reponse in catch if Stream or in finally if not stream
                var disposeReponseStatements = new ConditionStatement()
                {
                    Condition = new BinaryExpression(BinaryOperator.NotEquals, responseVariable, LiteralExpression.Null()),
                    TrueStatements = responseVariable.CreateInvokeMethodExpression("Dispose"),
                };

                if (method.ReturnType == ModelRef.File)
                {
                    responseTry.Catch = new CatchClauseCollection
                    {
                        new CatchClause()
                        {
                            Body = disposeReponseStatements,
                        },
                    };

                    responseTry.Catch[0].Body.Add(new ThrowStatement());
                }
                else
                {
                    responseTry.Finally = disposeReponseStatements;
                }

                // 4. Convert and return response object
                //    if (response.StatusCode == HttpStatusCode.NotFound) return default;
                if (method.MethodType == MethodType.Get)
                {
                    responseTry.Try.Add(new ConditionStatement()
                    {
                        Condition = new BinaryExpression(BinaryOperator.Equals, responseVariable.CreateMemberReferenceExpression("StatusCode"), new MemberReferenceExpression(typeof(HttpStatusCode), "NotFound")),
                        TrueStatements = new ReturnStatement(new DefaultValueExpression()),
                    });
                }

                // await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
                responseTry.Try.Add(new AwaitExpression(new MethodInvokeExpression(new MemberReferenceExpression(responseVariable, "EnsureStatusCodeAsync"), cancellationTokenArgument)).ConfigureAwait(false));

                if (method.ReturnType != null)
                {
                    // var result = await response.ToObjectAsync<T>(cancellationToken).ConfigureAwait(false);
                    var resultVariable = new VariableDeclarationStatement(m.ReturnType.Parameters[0].MakeNullable(), "result");
                    responseTry.Try.Add(resultVariable);
                    if (method.MethodType == MethodType.Get && method.ReturnType == ModelRef.File)
                    {
                        resultVariable.InitExpression = new AwaitExpression(responseVariable.CreateInvokeMethodExpression("ToStreamAsync", cancellationTokenArgument)).ConfigureAwait(false);
                    }
                    else if (method.MethodType == MethodType.GetCollection)
                    {
                        resultVariable.InitExpression = new AwaitExpression(responseVariable.CreateInvokeMethodExpression("ToCollectionAsync", new TypeReference[] { method.ReturnType.ToPropertyTypeReference() }, cancellationTokenArgument)).ConfigureAwait(false);
                    }
                    else
                    {
                        resultVariable.InitExpression = new AwaitExpression(responseVariable.CreateInvokeMethodExpression("ToObjectAsync", new TypeReference[] { method.ReturnType.ToPropertyTypeReference() }, cancellationTokenArgument)).ConfigureAwait(false);
                    }

                    // if (result is null)
                    //   throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to '{typeof(T)}' because the body is null or empty");
                    if (method.MethodType != MethodType.Get)
                    {
                        responseTry.Try.Add(new ConditionStatement()
                        {
                            Condition = new BinaryExpression(BinaryOperator.Equals, resultVariable, LiteralExpression.Null()),
                            TrueStatements = new ThrowStatement(new NewObjectExpression(WellKnownTypes.GitLabExceptionTypeReference,
                              responseVariable.CreateMemberReferenceExpression("RequestMethod"),
                              responseVariable.CreateMemberReferenceExpression("RequestUri"),
                              responseVariable.CreateMemberReferenceExpression("StatusCode"),
                              new LiteralExpression($"The response cannot be converted to '{method.ReturnType.ToPropertyTypeReference().ClrFullTypeName}' because the body is null or empty"))),
                        });
                    }

                    responseTry.Try.Add(new ReturnStatement(resultVariable));
                }
            }

            return m;

            static Expression GetHttpMethod(MethodType methodType)
            {
                return methodType switch
                {
                    MethodType.Get => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Get)),
                    MethodType.GetCollection => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Get)),
                    MethodType.GetPaged => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Get)),
                    MethodType.Put => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Put)),
                    MethodType.Post => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Post)),
                    MethodType.Delete => new MemberReferenceExpression(typeof(HttpMethod), nameof(HttpMethod.Delete)),
                    _ => throw new InvalidOperationException("Invalid method"),
                };
            }
        }

        private static IEnumerable<string> GetSegments(string url)
        {
            var list = new List<string>();

            var nextSeparator = ':';
            var span = url.AsSpan();
            while (!span.IsEmpty)
            {
                var index = span.IndexOf(nextSeparator);
                if (index > 0)
                {
                    list.Add(span[..index].ToString());
                }
                else
                {
                    if (span.EndsWith("[.format]", StringComparison.Ordinal))
                    {
                        list.Add(span.Slice(0, span.Length - "[.format]".Length).ToString());
                        list.Add(span[^"[.format]".Length..].ToString());
                    }
                    else
                    {
                        list.Add(span.ToString());
                    }

                    break;
                }

                span = span[index..];
                nextSeparator = nextSeparator == '/' ? ':' : '/';
            }

            return list;
        }

        private static void GenerateMethodSignature(Method method, MethodDeclaration m, TypeReference requestType, out MethodArgumentDeclaration requestDataArgument, out MethodArgumentDeclaration requestOptionsArgument, out MethodArgumentDeclaration cancellationTokenArgument)
        {
            AddDocumentationComments(m, method);

            if (method.MethodType == MethodType.GetPaged)
            {
                m.ReturnType = new TypeReference("Meziantou.GitLab.PagedResponse").MakeGeneric(method.ReturnType.ToPropertyTypeReference());
            }
            else
            {
                if (method.ReturnType != null)
                {
                    if (method.MethodType == MethodType.GetCollection || method.ReturnType.IsCollection)
                    {
                        m.ReturnType = new TypeReference(typeof(Task<>))
                            .MakeGeneric(new TypeReference(typeof(IReadOnlyList<>))
                                .MakeGeneric(method.ReturnType.ToPropertyTypeReference()));
                    }
                    else if (method.MethodType == MethodType.Get)
                    {
                        m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(method.ReturnType.ToPropertyTypeReference().MakeNullable());
                    }
                    else
                    {
                        m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(method.ReturnType.ToPropertyTypeReference());
                    }
                }
                else
                {
                    m.ReturnType = new TypeReference(typeof(Task));
                }
            }

            if (requestType != null)
            {
                requestDataArgument = m.AddArgument(new MethodArgumentDeclaration(requestType, "request"));
            }
            else
            {
                requestDataArgument = null;
            }

            requestOptionsArgument = m.AddArgument(new MethodArgumentDeclaration(ModelRef.RequestOptions.ToArgumentTypeReference().MakeNullable(), "requestOptions") { DefaultValue = new DefaultValueExpression(ModelRef.RequestOptions.ToArgumentTypeReference()) });
            AddDocumentationComments(requestOptionsArgument, new Documentation()
            {
                Summary = "Options of the request",
            });

            if (method.MethodType != MethodType.GetPaged)
            {
                cancellationTokenArgument = m.AddArgument(new MethodArgumentDeclaration(typeof(CancellationToken), "cancellationToken") { DefaultValue = new DefaultValueExpression(typeof(CancellationToken)) });
                AddDocumentationComments(cancellationTokenArgument, new Documentation()
                {
                    Summary = "A cancellation token that can be used by other objects or threads to receive notice of cancellation",
                });
            }
            else
            {
                cancellationTokenArgument = null;
            }
        }

        private static TypeReference CreateMethodArgumentType(NamespaceDeclaration namespaceDeclaration, Method method)
        {
            var groupName = method.MethodGroup.Name.Singularize();
            string name;
            if (method.RequestTypeName != null)
            {
                name = method.RequestTypeName + "Request";
            }
            else if (method.Name.Contains(groupName, StringComparison.Ordinal))
            {
                name = method.Name + "Request";
            }
            else
            {
                name = method.Name + groupName + "Request";
            }

            var type = namespaceDeclaration.AddType(new ClassDeclaration(name));
            type.Modifiers = Modifiers.Public | Modifiers.Partial;

            var ctor = type.AddMember(new ConstructorDeclaration());
            ctor.Modifiers = Modifiers.Public;

            // properties
            foreach (var param in method.Parameters)
            {
                var paramType = GetArgumentTypeRef(param).MakeNullable();

                // field
                var field = type.AddMember(new FieldDeclaration(ToFieldName(param.Name), paramType));
                field.Modifiers = Modifiers.Private;

                // property getter/setter
                var property = type.AddMember(new PropertyDeclaration(ToPropertyName(param.Name), paramType));
                property.Modifiers = Modifiers.Public;
                property.Getter = new PropertyAccessorDeclaration(new ReturnStatement(field));
                property.Setter = new PropertyAccessorDeclaration(new AssignStatement(field, new ArgumentReferenceExpression("value")));
                AddDocumentationComments(property, param.Documentation);

                if (GetParameterLocation(method, param) != ParameterLocation.Body)
                {
                    property.CustomAttributes.Add(new CustomAttribute(typeof(JsonIgnoreAttribute)));
                }
                else
                {
                    property.CustomAttributes.Add(new CustomAttribute(typeof(JsonPropertyNameAttribute))
                    {
                        Arguments = { new CustomAttributeArgument(new LiteralExpression(param.Name)) },
                    });

                    if (!param.IsRequired)
                    {
                        property.CustomAttributes.Add(new CustomAttribute(typeof(JsonIgnoreAttribute))
                        {
                            Arguments = { new CustomAttributeArgument(nameof(JsonIgnoreAttribute.Condition), new MemberReferenceExpression(typeof(JsonIgnoreCondition), nameof(JsonIgnoreCondition.WhenWritingNull))) },
                        });
                    }
                }

                // ctor required properties
                if (param.IsRequired)
                {
                    var argument = new MethodArgumentDeclaration(paramType, ToArgumentName(param.Name));
                    ctor.Arguments.Add(argument);
                    ctor.Statements.Add(new AssignStatement(field, argument));
                    AddDocumentationComments(argument, param.Documentation);
                }
            }

            if (ctor.Arguments.Count > 0)
            {
                var defaultCtor = type.AddMember(new ConstructorDeclaration());
                defaultCtor.Modifiers = Modifiers.Public;
                defaultCtor.Statements = new StatementCollection();
            }

            return type;
        }

        private static void CreateBodyArgument(Method method, StatementCollection statements, MethodArgumentDeclaration requestArgument, VariableReferenceExpression httpRequestVariable)
        {
            var bodyArguments = method.Parameters.Where(p => GetParameterLocation(method, p) == ParameterLocation.Body).ToList();
            if (bodyArguments.Count == 0)
                return;

            var binaryDataArg = bodyArguments.Where(arg => arg.Type == ModelRef.FileUpload).ToList();
            if (binaryDataArg.Count > 0)
            {
                // FormData
                var contentVariable = new VariableDeclarationStatement(typeof(MultipartFormDataContent), "content", new NewObjectExpression(typeof(MultipartFormDataContent)));
                statements.Add(contentVariable);

                foreach (var arg in bodyArguments)
                {
                    var condition = new ConditionStatement
                    {
                        Condition = new BinaryExpression(BinaryOperator.NotEquals, requestArgument.CreateMemberReferenceExpression(ToPropertyName(arg.Name)), new LiteralExpression(value: null)),
                    };

                    if (arg.Type == ModelRef.FileUpload)
                    {
                        condition.TrueStatements = contentVariable.CreateInvokeMethodExpression(nameof(MultipartFormDataContent.Add),
                            requestArgument.CreateMemberReferenceExpression(ToPropertyName(arg.Name)).CreateInvokeMethodExpression("ToHttpContent"),
                            arg.Name,
                            requestArgument.CreateMemberReferenceExpression(ToPropertyName(arg.Name)).CreateMemberReferenceExpression("FileName"));
                    }
                    else
                    {
                        // FormUrlEncodedContent, Convert value to string
                        throw new NotSupportedException("This case is not yet implemented");
                    }
                    statements.Add(condition);
                }

                statements.Add(new AssignStatement(httpRequestVariable.CreateMemberReferenceExpression(nameof(HttpRequestMessage.Content)), contentVariable));
            }
            else
            {
                // JsonContent
                statements.Add(new AssignStatement(httpRequestVariable.CreateMemberReferenceExpression(nameof(HttpRequestMessage.Content)), new NewObjectExpression(WellKnownTypes.JsonContentTypeReference, requestArgument, new MemberReferenceExpression(WellKnownTypes.JsonSerializationTypeReference, "Options"))));
            }
        }

        private static void GenerateMandatoryParameterExtensions(ClassDeclaration extensionClass, Method method, TypeReference interfaceReference, TypeReference requestType)
        {
            if (requestType == null)
                return;

            // Generate all versions
            var versions = method.Parameters.Select(p => p.Version).Distinct().DefaultIfEmpty();
            var lastVersion = method.Parameters.Select(p => p.Version).DefaultIfEmpty().Max();

            foreach (var version in versions)
            {
                var parameters = method.Parameters.Where(p => p.Version <= version).ToArray();

                var m = extensionClass.AddMember(new MethodDeclaration(GetMethodName(method)));
                GenerateMethodSignature(method, m, requestType, out var requestArgument, out var requestOptionsArgument, out var cancellationTokenArgument);
                m.Modifiers = Modifiers.Public | Modifiers.Static;
                var clientArgument = new MethodArgumentDeclaration(interfaceReference, "client") { IsExtension = true };
                m.Arguments.Remove(requestArgument);
                m.Arguments.Insert(0, clientArgument);
                m.Statements = new StatementCollection();

                var ctor = new NewObjectExpression(requestType);
                var requestVariable = new VariableDeclarationStatement(requestType, "request", initExpression: ctor);
                m.Statements.Add(requestVariable);

                var parameterIndex = 1;
                foreach (var param in parameters)
                {
                    // Argument
                    var paramArgument = new MethodArgumentDeclaration(GetArgumentTypeRef(param), ToArgumentName(param.Name));
                    if (!param.IsRequired && version == lastVersion)
                    {
                        paramArgument.DefaultValue = new DefaultValueExpression(paramArgument.Type);
                    }

                    m.Arguments.Insert(parameterIndex, paramArgument);

                    // Use argument in ctor or use setter
                    if (param.IsRequired)
                    {
                        ctor.Arguments.Add(paramArgument);
                    }
                    else
                    {
                        m.Statements.Add(new AssignStatement(
                            new MemberReferenceExpression(requestVariable, ToPropertyName(param.Name)),
                            paramArgument));
                    }

                    parameterIndex++;
                }

                var invokeArguments = new List<MethodInvokeArgumentExpression> { requestArgument };
                for (var i = parameterIndex; i < m.Arguments.Count; i++)
                {
                    invokeArguments.Add(m.Arguments[i]);
                }

                m.Statements.Add(new ReturnStatement(
                    new MethodInvokeExpression(
                        new MemberReferenceExpression(clientArgument, m.Name),
                        invokeArguments.ToArray())));
            }
        }

        private static Expression FormatValue(ModelRef modelRef, Expression expression)
        {
            if (modelRef == ModelRef.Date || modelRef == ModelRef.NullableDate)
            {
                return new MethodInvokeExpression(new MemberReferenceExpression(WellKnownTypes.GitLabDateJsonConverterTypeReference, "FormatValue"), expression);
            }

            return expression;
        }
    }
}
