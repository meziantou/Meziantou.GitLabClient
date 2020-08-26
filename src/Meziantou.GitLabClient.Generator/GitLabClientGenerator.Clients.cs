using System;
using System.Collections.Generic;
using System.Linq;
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

        private static MethodDeclaration GenerateMethod(ClassDeclaration clientClass, Method method, TypeReference requestType)
        {
            var m = clientClass.AddMember(new MethodDeclaration(method.MethodGroup.Name + '_' + GetMethodName(method)));
            m.SetData("Method", method);
            GenerateMethodSignature(method, m, requestType, out var requestArgument, out var requestOptionsArgument, out var cancellationTokenArgument);
            m.Modifiers = Modifiers.Private;

            // Method body
            m.Statements = new StatementCollection();

            var urlBuilder = new VariableDeclarationStatement(
                WellKnownTypes.UrlBuilderTypeReference, "urlBuilder",
                new TypeReferenceExpression(WellKnownTypes.UrlBuilderTypeReference).CreateInvokeMethodExpression("Get", method.UrlTemplate));
            m.Statements.Add(urlBuilder);

            foreach (var param in method.Parameters.Where(p => GetParameterLocation(method, p) == ParameterLocation.Url))
            {
                if (param.Type.IsParameterEntity)
                {
                    var propertyName = param.Type.ParameterEntity.FinalType == ModelRef.Object ? "ValueAsString" : "Value";
                    //if (param.Type.IsNullable || !param.IsRequired)
                    //{
                    var hasValueCondition = new ConditionStatement
                    {
                        Condition = CreatePropertyReference().CreateMemberReferenceExpression(nameof(Nullable<int>.HasValue)),
                        TrueStatements = urlBuilder
                            .CreateInvokeMethodExpression(
                                "SetValue",
                                param.Name,
                                CreatePropertyReference().CreateMemberReferenceExpression(nameof(Nullable<int>.Value), propertyName)),
                    };
                    m.Statements.Add(hasValueCondition);
                    //}
                    //else
                    //{
                    //    var propertyReference = CreatePropertyReference().CreateMemberReferenceExpression(propertyName);
                    //    m.Statements.Add(urlBuilder.CreateInvokeMethodExpression("SetValue", param.Name, propertyReference));
                    //}
                }
                else
                {
                    m.Statements.Add(urlBuilder.CreateInvokeMethodExpression("SetValue", param.Name, CreatePropertyReference()));
                }

                MemberReferenceExpression CreatePropertyReference()
                {
                    return requestArgument.CreateMemberReferenceExpression(ToPropertyName(param.Name));
                }
            }

            var url = new VariableDeclarationStatement(typeof(string), "url", urlBuilder.CreateInvokeMethodExpression("Build"));
            m.Statements.Add(url);

            var bodyArgument = CreateBodyArgument(method, m);
            switch (method.MethodType)
            {
                case MethodType.Get:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("GetAsync", new TypeReference[] { method.ReturnType.ToPropertyTypeReference() }, url, requestOptionsArgument, cancellationTokenArgument)));
                    break;

                case MethodType.GetCollection:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("GetCollectionAsync", new TypeReference[] { method.ReturnType.ToPropertyTypeReference() }, url, requestOptionsArgument, cancellationTokenArgument)));
                    break;

                case MethodType.GetPaged:
                    m.Statements.Add(new ReturnStatement(new NewObjectExpression(m.ReturnType!.Clone(), new ThisExpression(), url, requestOptionsArgument)));
                    break;

                case MethodType.Put:
                case MethodType.Post:
                    var postArgs = new List<Expression>
                    {
                        url,
                        (Expression)bodyArgument ?? new LiteralExpression(value: null),
                        requestOptionsArgument,
                        cancellationTokenArgument!,
                    };
                    if (method.ReturnType != null)
                    {
                        m.Statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression(method.MethodType + "JsonAsync", new TypeReference[] { method.ReturnType.ToPropertyTypeReference() }, postArgs.ToArray())));
                    }
                    else
                    {
                        m.Statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression(method.MethodType + "JsonAsync", postArgs.ToArray())));
                    }
                    break;

                case MethodType.Delete:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("DeleteAsync", url, requestOptionsArgument, cancellationTokenArgument)));
                    break;

                default:
                    throw new NotSupportedException($"Method {method.MethodType} is not supported");
            }

            return m;
        }

        private static void GenerateMethodSignature(Method method, MethodDeclaration m, TypeReference requestType, out MethodArgumentDeclaration requestDataArgument, out MethodArgumentDeclaration requestOptionsArgument, out MethodArgumentDeclaration cancellationTokenArgument)
        {
            AddDocumentationComments(m, method.Documentation);

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
                    else
                    {
                        if (method.MethodType == MethodType.Get)
                        {
                            m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(method.ReturnType.ToPropertyTypeReference().MakeNullable());
                        }
                        else
                        {
                            m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(method.ReturnType.ToPropertyTypeReference());
                        }
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
            if (method.Parameters.Count == 0)
                return null;

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

                // ctor required properties
                if (param.IsRequired)
                {
                    var argument = new MethodArgumentDeclaration(paramType, ToArgumentName(param.Name));
                    ctor.Arguments.Add(argument);
                    ctor.Statements.Add(new AssignStatement(field, argument));
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

        private static VariableReferenceExpression CreateBodyArgument(Method method, MethodDeclaration methodDeclaration)
        {
            var bodyArguments = method.Parameters.Where(p => GetParameterLocation(method, p) == ParameterLocation.Body).ToList();
            if (bodyArguments.Count == 0)
                return null;

            var variable = new VariableDeclarationStatement(typeof(Dictionary<string, object>), "body");
            methodDeclaration.Statements.Add(variable);
            variable.InitExpression = new NewObjectExpression(typeof(Dictionary<string, object>));
            foreach (var arg in bodyArguments)
            {
                Expression CreateArgumentReference() => new ArgumentReferenceExpression("request").CreateMemberReferenceExpression(ToPropertyName(arg.Name));

                var assign = variable.CreateInvokeMethodExpression(nameof(Dictionary<string, object>.Add), arg.Name, CreateArgumentReference());
                //if (!arg.IsRequired)
                //{
                var condition = new ConditionStatement
                {
                    Condition = new BinaryExpression(BinaryOperator.NotEquals, CreateArgumentReference(), new LiteralExpression(value: null)),
                    TrueStatements = assign,
                };
                methodDeclaration.Statements.Add(condition);
                //}
                //else
                //{
                //    methodDeclaration.Statements.Add(assign);
                //}
            }

            return variable;
        }

        private static void GenerateMandatoryParameterExtensions(ClassDeclaration extensionClass, Method method, TypeReference interfaceReference, TypeReference requestType)
        {
            if (requestType == null)
                return;

            // Generate all versions
            var versions = method.Parameters.Select(p => p.Version).Distinct();
            var lastVersion = method.Parameters.Max(p => p.Version);

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
    }
}
