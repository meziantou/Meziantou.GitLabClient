using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Meziantou.Framework.CodeDom;
using Meziantou.GitLab;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class Program
    {
        public bool MustGenerateEmoji => false;

        internal Project Project { get; set; } = new Project();

        private static void Main()
        {
            new Program().Generate();
        }

        public void Generate()
        {
            CreateProject();

            // Generate code
            var unit = new CompilationUnit();
            var ns = unit.AddNamespace("Meziantou.GitLab");
            foreach (var model in Project.Models.OrderBy(m => m.Name))
            {
                GenerateModel(ns, model, isRequestPayload: false);
            }

            foreach (var entity in Project.ParameterEntities.OrderBy(p => p.Name))
            {
                GenerateParameterEntities(ns, entity);
            }

            foreach (var model in Project.RequestPayloads.OrderBy(m => m.Name))
            {
                GenerateModel(ns, model, isRequestPayload: true);
            }

            var clientClass = ns.AddType(new ClassDeclaration("GitLabClient") { Modifiers = Modifiers.Partial });
            foreach (var method in Project.Methods)
            {
                GenerateMethod(clientClass, method);

                foreach (var param in method.Parameters.Where(p => p.Type.IsParameterEntity))
                {
                    foreach (var entity in param.Type.ParameterEntity.Refs.Where(r => r.ModelRef.IsModel))
                    {
                        var type = ns.Types.OfType<ClassDeclaration>().First(t => t.Name == entity.ModelRef.Model.Name);
                        GenerateExtensionMethod(type, method, param);
                    }
                }
            }

            using (var tw = new StreamWriter("../../../../Meziantou.GitLabClient/GitLabClient.generated.cs"))
            {
                new CSharpCodeGenerator().Write(tw, unit);
            }

            if (MustGenerateEmoji)
            {
                GenerateEmoji();
            }
        }

        private void CreateProject()
        {
            CreateEnumerations();
            CreateUserTypes();
            CreateRefs();

            // Call CreateXXXMethods()
            foreach (var method in GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(m => m.Name.StartsWith("Create") && m.Name.EndsWith("Methods")))
            {
                method.Invoke(this, Array.Empty<object>());
            }
        }

        private void GenerateEmoji()
        {
            var unit = new CompilationUnit();
            var ns = unit.AddNamespace("Meziantou.GitLab");

            var emojiClass = ns.AddType(new ClassDeclaration("Emoji") { Modifiers = Modifiers.Public | Modifiers.Partial | Modifiers.Static });

            using (var httpClient = new HttpClient())
            {
                using (var result = httpClient.GetAsync("https://raw.githubusercontent.com/jonathanwiesel/gemojione/master/config/index.json").Result)
                {
                    var str = result.Content.ReadAsStringAsync().Result;
                    var emojis = JsonConvert.DeserializeObject<Dictionary<string, EmojiResponse>>(str);
                    foreach (var kvp in emojis.OrderBy(entry => entry.Key))
                    {
                        var field = emojiClass.AddMember(new FieldDeclaration("Emoji" + GetName(kvp.Key), typeof(string), Modifiers.Public | Modifiers.Const) { InitExpression = new LiteralExpression(kvp.Key) });
                        field.CommentsBefore.Add(new Comment(new XElement("summary", $"Emoji {kvp.Value.Name} {kvp.Value.Moji}").ToString(), CommentType.DocumentationComment));
                    }
                }
            }

            using (var tw = new StreamWriter("../../../../Meziantou.GitLabClient/Emoji.cs"))
            {
                new CSharpCodeGenerator().Write(tw, unit);
            }

            string GetName(string value)
            {
                return value.Split(new[] { '_', '-' }, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
            }
        }

        private void AddDocumentationComments(ICommentable commentable, Documentation documentation)
        {
            if (documentation != null)
            {
                if (commentable is MethodArgumentDeclaration arg)
                {
                    var method = arg.GetSelfOrParentOfType<MethodDeclaration>();
                    if (documentation.Summary != null)
                    {
                        method.CommentsBefore.Add(new Comment(new XElement("param", new XAttribute("name", arg.Name), documentation.Summary).ToString(), CommentType.DocumentationComment));
                    }
                }
                else
                {
                    if (documentation.Summary != null)
                    {
                        commentable.CommentsBefore.Add(new Comment(new XElement("summary", documentation.Summary).ToString(), CommentType.DocumentationComment));
                    }

                    if (documentation.Remark != null)
                    {
                        commentable.CommentsBefore.Add(new Comment(new XElement("remark", documentation.Remark).ToString(), CommentType.DocumentationComment));
                    }

                    if (documentation.Returns != null)
                    {
                        commentable.CommentsBefore.Add(new Comment(new XElement("returns", documentation.Returns).ToString(), CommentType.DocumentationComment));
                    }
                }
            }
        }

        private MethodDeclaration GenerateMethod(ClassDeclaration clientClass, Method method)
        {
            var m = clientClass.AddMember(new MethodDeclaration(method.Name + "Async"));
            AddDocumentationComments(m, method.Documentation);

            // Method signature
            m.Modifiers = Modifiers.Public;
            if (method.MethodType == MethodType.GetPaged)
            {
                m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(new TypeReference("Meziantou.GitLab.PagedResponse").MakeGeneric(method.ReturnType));
            }
            else
            {
                if (method.ReturnType != null)
                {
                    if (method.ReturnType.IsCollection)
                    {
                        m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(new TypeReference(typeof(IReadOnlyList<>)).MakeGeneric(method.ReturnType));
                    }
                    else
                    {
                        m.ReturnType = new TypeReference(typeof(Task<>)).MakeGeneric(method.ReturnType);
                    }
                }
                else
                {
                    m.ReturnType = new TypeReference(typeof(Task));
                }
            }

            var arguments = new Dictionary<MethodParameter, MethodArgumentDeclaration>();
            foreach (var param in method.Parameters.OrderBy(p => p.IsOptional ? 1 : -1))
            {
                var argument = m.AddArgument(new MethodArgumentDeclaration(GetArgumentTypeRef(param.Type), param.MethodParameterName ?? ToArgumentName(param.Name)));
                if (param.IsOptional)
                {
                    argument.DefaultValue = new DefaultValueExpression(argument.Type.Clone());
                }

                arguments.Add(param, argument);
                argument.SetData("Parameter", param);
                AddDocumentationComments(argument, param.Documentation);
            }

            MethodArgumentDeclaration pageArgument = null;
            if (method.MethodType == MethodType.GetPaged)
            {
                pageArgument = m.AddArgument(new MethodArgumentDeclaration(typeof(PageOptions), "pageOptions") { DefaultValue = new DefaultValueExpression(typeof(PageOptions)) });

                AddDocumentationComments(pageArgument, new Documentation()
                {
                    Summary = "The page index and page size"
                });
            }

            var cancellationTokenArgument = m.AddArgument(new MethodArgumentDeclaration(typeof(CancellationToken), "cancellationToken") { DefaultValue = new DefaultValueExpression(typeof(CancellationToken)) });
            AddDocumentationComments(cancellationTokenArgument, new Documentation()
            {
                Summary = "A cancellation token that can be used by other objects or threads to receive notice of cancellation."
            });

            // Method body
            m.Statements = new StatementCollection();

            var urlBuilder = new VariableDeclarationStatement(
                typeof(UrlBuilder), "urlBuilder",
                new TypeReference(typeof(UrlBuilder)).InvokeMethod("Get", method.UrlTemplate));
            m.Statements.Add(urlBuilder);

            foreach (var param in method.Parameters.Where(p => GetLocation(method, p) == ParameterLocation.Url))
            {
                if (param.Type.IsParameterEntity)
                {
                    if (param.Type.IsNullable)
                    {
                        var hasValueCondition = new ConditionStatement();
                        hasValueCondition.Condition = arguments[param].GetMember(nameof(Nullable<int>.HasValue));
                        hasValueCondition.TrueStatements = urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), param.Name, arguments[param].GetMember(nameof(Nullable<int>.Value), "Value"));
                        m.Statements.Add(hasValueCondition);
                    }
                    else
                    {
                        m.Statements.Add(urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), param.Name, arguments[param].GetMember("Value")));
                    }
                }
                else
                {
                    m.Statements.Add(urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), param.Name, arguments[param]));
                }
            }

            if (pageArgument != null)
            {
                var pageCondition = new ConditionStatement()
                {
                    Condition = new BinaryExpression(BinaryOperator.NotEquals, pageArgument, new LiteralExpression(null)),
                    TrueStatements = new StatementCollection
                    {
                        new ConditionStatement()
                        {
                            Condition = new BinaryExpression(BinaryOperator.GreaterThan, pageArgument.GetMember(nameof(PageOptions.PageIndex)), new LiteralExpression(0)),
                            TrueStatements = new StatementCollection
                            {
                                urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), "page", pageArgument.GetMember(nameof(PageOptions.PageIndex)))
                            }
                        },
                        new ConditionStatement()
                        {
                            Condition = new BinaryExpression(BinaryOperator.GreaterThan, pageArgument.GetMember(nameof(PageOptions.PageSize)), new LiteralExpression(0)),
                            TrueStatements = new StatementCollection
                            {
                                urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), "per_page", pageArgument.GetMember(nameof(PageOptions.PageSize)))
                            }
                        },
                        new ConditionStatement()
                        {
                            Condition = new BinaryExpression(BinaryOperator.Equals, pageArgument.GetMember(nameof(PageOptions.OrderBy), nameof(OrderBy.Name)).IsNullOrEmpty(), new LiteralExpression(false)),
                            TrueStatements = new StatementCollection
                            {
                                urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), "order_by", pageArgument.GetMember(nameof(PageOptions.OrderBy), nameof(OrderBy.Name))),
                                urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), "sort", pageArgument.GetMember(nameof(PageOptions.OrderBy), nameof(OrderBy.Direction)))
                            }
                        }
                    }
                };

                m.Statements.Add(pageCondition);
            }

            var url = new VariableDeclarationStatement(typeof(string), "url", urlBuilder.InvokeMethod(nameof(UrlBuilder.Build)));
            m.Statements.Add(url);

            var bodyArgument = CreateBodyArgument(method, m);
            switch (method.MethodType)
            {
                case MethodType.Get:
                    if (method.ReturnType.IsCollection)
                    {
                        m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("GetCollectionAsync", new TypeReference[] { method.ReturnType }, url, cancellationTokenArgument)));
                    }
                    else
                    {
                        m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("GetAsync", new TypeReference[] { method.ReturnType }, url, cancellationTokenArgument)));
                    }

                    break;

                case MethodType.GetPaged:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("GetPagedAsync", new TypeReference[] { method.ReturnType }, url, cancellationTokenArgument)));
                    break;

                case MethodType.Put:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("PutJsonAsync", new TypeReference[] { method.ReturnType }, url, bodyArgument, cancellationTokenArgument)));
                    break;

                case MethodType.Post:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("PostJsonAsync", new TypeReference[] { method.ReturnType }, url, bodyArgument, cancellationTokenArgument)));
                    break;

                case MethodType.Delete:
                    m.Statements.Add(new ReturnStatement(new ThisExpression().InvokeMethod("DeleteAsync", url, cancellationTokenArgument)));
                    break;

                default:
                    throw new NotSupportedException($"Method {method.MethodType} is not supported");
            }

            return m;
        }

        private VariableReference CreateBodyArgument(Method method, MethodDeclaration methodDeclaration)
        {
            var bodyArguments = method.Parameters.Where(p => GetLocation(method, p) == ParameterLocation.Body).ToList();
            if (bodyArguments.Count == 0)
                return null;

            var variable = new VariableDeclarationStatement(typeof(Dictionary<string, object>), "body");
            methodDeclaration.Statements.Add(variable);
            variable.InitExpression = new NewObjectExpression(typeof(Dictionary<string, object>));
            foreach (var arg in bodyArguments)
            {
                var argumentReference = methodDeclaration.Arguments.First(a => a.Data["Parameter"] == arg);
                var assign = variable.InvokeMethod(nameof(Dictionary<string, object>.Add), arg.Name, argumentReference);
                if (arg.IsOptional)
                {
                    var condition = new ConditionStatement();
                    condition.Condition = new BinaryExpression(BinaryOperator.NotEquals, argumentReference, new LiteralExpression(null));
                    condition.TrueStatements = assign;
                    methodDeclaration.Statements.Add(condition);
                }
                else
                {
                    methodDeclaration.Statements.Add(assign);
                }
            }

            return variable;
        }

        private void GenerateExtensionMethod(ClassDeclaration clientClass, Method method, MethodParameter methodParameter)
        {
            var m = GenerateMethod(clientClass, method);
            m.Statements.Clear();

            var invoke = new MethodInvokeExpression(new ThisExpression().GetMember("GitLabClient", m.Name));

            foreach (var arg in m.Arguments.ToList())
            {
                if (arg.Data.TryGetValue("Parameter", out var parameter) && methodParameter == parameter)
                {
                    m.Arguments.Remove(arg);
                    invoke.Arguments.Add(new ThisExpression());
                }
                else
                {
                    invoke.Arguments.Add(arg);
                }
            }

            m.Statements.Add(new ReturnStatement(invoke));
            m.Name = m.Name.Replace(clientClass.Name, "", StringComparison.OrdinalIgnoreCase);
        }

        private void GenerateModel(NamespaceDeclaration ns, Model model, bool isRequestPayload)
        {
            if (model is Entity entity)
            {
                var type = ns.AddType(new ClassDeclaration(entity.Name));
                AddDocumentationComments(type, entity.Documentation);
                type.Modifiers = Modifiers.Public | Modifiers.Partial;
                type.BaseType = entity.BaseType ?? (isRequestPayload ? null : ModelRef.GitLabObject);
                foreach (var prop in entity.Properties)
                {
                    var field = type.AddMember(new FieldDeclaration(ToFieldName(prop.Name), GetPropertyTypeRef(prop.Type), Modifiers.Private));
                    var propertyMember = type.AddMember(new PropertyDeclaration(ToPropertyName(prop.Name), GetPropertyTypeRef(prop.Type))
                    {
                        Modifiers = Modifiers.Public,
                        Getter = new ReturnStatement(field),
                        Setter = new PropertyMemberDeclaration
                        {
                            Modifiers = isRequestPayload ? Modifiers.None : Modifiers.Private,
                            Statements = new AssignStatement(field, new ValueArgumentExpression())
                        },
                    });

                    AddDocumentationComments(propertyMember, prop.Documentation);

                    if (prop.Type == ModelRef.Date || prop.Type == ModelRef.NullableDate)
                    {
                        propertyMember.CustomAttributes.Add(new CustomAttribute(typeof(SkipUtcDateValidationAttribute)) { Arguments = { new CustomAttributeArgument("Does not contain time nor timezone (e.g. 2018-01-01)") } });
                    }

                    // [Newtonsoft.Json.JsonProperty(PropertyName = "")]
                    var jsonPropertyAttribute = new CustomAttribute(typeof(JsonPropertyAttribute))
                    {
                        Arguments =
                        {
                            new CustomAttributeArgument(nameof(JsonPropertyAttribute.PropertyName), prop.SerializationName ?? prop.Name),
                            //new CustomAttributeArgument(nameof(JsonPropertyAttribute.Required), RequiredMode(prop)),
                        }
                    };
                    propertyMember.CustomAttributes.Add(jsonPropertyAttribute);

                    // [JsonConverterAttribute(typeof())]
                    if (prop.JsonConverter != null)
                    {
                        var jsonConverterAttribute = new CustomAttribute(typeof(JsonConverterAttribute))
                        {
                            Arguments =
                            {
                                new CustomAttributeArgument(new TypeOfExpression(GetPropertyTypeRef(prop.JsonConverter))),
                            }
                        };

                        propertyMember.CustomAttributes.Add(jsonConverterAttribute);
                    }

                }
            }
            else if (model is Enumeration enumeration)
            {
                var type = ns.AddType(new EnumerationDeclaration(enumeration.Name));
                AddDocumentationComments(type, enumeration.Documentation);
                type.Modifiers = Modifiers.Public;
                type.BaseType = enumeration.BaseType;

                if (enumeration.IsFlags)
                {
                    type.CustomAttributes.Add(new CustomAttribute(typeof(FlagsAttribute)));
                }

                if (enumeration.SerializeAsString)
                {
                    //[JsonConverter(typeof(StringEnumConverter))]
                    type.CustomAttributes.Add(new CustomAttribute(typeof(JsonConverterAttribute))
                    {
                        Arguments = { new CustomAttributeArgument(new TypeOfExpression(typeof(StringEnumConverter))) }
                    });
                }

                foreach (var prop in enumeration.Members)
                {
                    var enumerationMember = new Framework.CodeDom.EnumerationMember(ToPropertyName(prop.Name));
                    if (prop.Value != null)
                    {
                        enumerationMember.Value = new LiteralExpression(prop.Value);
                    }

                    if (enumeration.SerializeAsString)
                    {
                        enumerationMember.CustomAttributes.Add(new CustomAttribute(typeof(EnumMemberAttribute))
                        {
                            Arguments = { new CustomAttributeArgument(nameof(EnumMemberAttribute.Value), prop.SerializationName ?? prop.Name) }
                        });
                    }

                    AddDocumentationComments(enumerationMember, prop.Documentation);
                    type.Members.Add(enumerationMember);
                }

                if (enumeration.GenerateAllMember)
                {
                    Expression initExpression = null;
                    foreach (var member in type.Members)
                    {
                        Expression memberExpression = new TypeReference(type).GetMember(member.Name);
                        if (initExpression == null)
                        {
                            initExpression = memberExpression;
                        }
                        else
                        {
                            initExpression = new BinaryExpression(BinaryOperator.BitwiseOr, initExpression, memberExpression);
                        }
                    }

                    var enumerationMember = new Framework.CodeDom.EnumerationMember(ToPropertyName("all"), initExpression);
                    type.Members.Add(enumerationMember);
                }
            }

            Required RequiredMode(EntityProperty property)
            {
                if (property.Required.HasValue)
                    return property.Required.Value;

                if (property.Type.IsNullable)
                    return Required.AllowNull;

                if (property.Type.IsModel)
                    return Required.AllowNull;

                return Required.Always;
            }
        }

        private void GenerateParameterEntities(NamespaceDeclaration ns, ParameterEntity entity)
        {
            var type = ns.AddType(new StructDeclaration(entity.Name));
            type.Modifiers = Modifiers.Public | Modifiers.ReadOnly;

            type.Implements.Add(typeof(IReference));
            type.CustomAttributes.Add(new CustomAttribute(typeof(JsonConverterAttribute))
            {
                Arguments =
                {
                    new CustomAttributeArgument(new TypeOfExpression(typeof(ReferenceJsonConverter)))
                }
            });

            // Add Value Property (readonly)
            var valueField = new FieldDeclaration("_value", GetPropertyTypeRef(entity.FinalType), Modifiers.Private | Modifiers.ReadOnly);
            var valueProperty = new PropertyDeclaration("Value", GetPropertyTypeRef(entity.FinalType))
            {
                Modifiers = Modifiers.Public,
                Getter = new PropertyMemberDeclaration
                {
                    Statements = new ReturnStatement(valueField)
                }
            };

            type.AddMember(valueField);
            type.AddMember(valueProperty);

            foreach (var refe in entity.Refs)
            {
                var addNullCheck = refe.ModelRef.Model != null;

                // Add constructor
                var ctor = type.AddMember(new ConstructorDeclaration()
                {
                    Modifiers = Modifiers.Public,
                    Arguments =
                    {
                        new MethodArgumentDeclaration(GetPropertyTypeRef(refe.ModelRef), "value"),
                    },
                    Statements =
                    {
                        new AssignStatement(valueField, GetAssignExpression())
                    }
                });

                if (addNullCheck)
                {
                    ctor.Statements.Insert(0, ctor.Arguments[0].CreateThrowIfNullStatement());
                }

                // Add implicit converter
                var implicitOperator = type.AddMember(new OperatorDeclaration()
                {
                    Modifiers = Modifiers.Public | Modifiers.Static | Modifiers.Implicit,
                    ReturnType = type,
                    Arguments =
                    {
                         new MethodArgumentDeclaration(GetPropertyTypeRef(refe.ModelRef), "value"),
                    },
                    Statements =
                    {
                        new ReturnStatement(new NewObjectExpression(type, new ArgumentReferenceExpression("value")))
                    }
                });

                if (addNullCheck)
                {
                    implicitOperator.Statements.Insert(0, implicitOperator.Arguments[0].CreateThrowIfNullStatement());
                }

                Expression GetAssignExpression()
                {
                    Expression value = new ArgumentReferenceExpression("value");
                    foreach (var member in refe.Properties)
                    {
                        value = value.GetMember(ToPropertyName(member));
                    }

                    return value;
                }
            }
        }

        private string ToFieldName(string value)
        {
            var pascalCase = ToPropertyName(value);
            return "_" + char.ToLowerInvariant(pascalCase[0]) + pascalCase.Substring(1);
        }

        private string ToPropertyName(string value)
        {
            return value.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
             .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
             .Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        private string ToArgumentName(string value)
        {
            var pascalCase = ToPropertyName(value);
            return char.ToLowerInvariant(pascalCase[0]) + pascalCase.Substring(1);
        }

        private ParameterLocation GetLocation(Method method, MethodParameter parameter)
        {
            if (parameter.Location != ParameterLocation.Default)
            {
                return parameter.Location;
            }

            if (method.UrlTemplate.Contains($":{parameter.Name}/") || method.UrlTemplate.EndsWith($":{parameter.Name}"))
                return ParameterLocation.Url;

            switch (method.MethodType)
            {
                case MethodType.Get:
                case MethodType.GetPaged:
                    return ParameterLocation.Url;

                case MethodType.Put:
                case MethodType.Post:
                case MethodType.Delete:
                    return ParameterLocation.Body;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private TypeReference GetPropertyTypeRef(ModelRef modelRef)
        {
            var typeRef = (TypeReference)modelRef;
            if (modelRef.IsCollection)
            {
                typeRef = new TypeReference(typeof(IReadOnlyList<>)).MakeGeneric(typeRef);
            }

            return typeRef;
        }

        private TypeReference GetArgumentTypeRef(ModelRef modelRef)
        {
            var typeRef = (TypeReference)modelRef;
            if (modelRef.IsCollection)
            {
                typeRef = new TypeReference(typeof(IEnumerable<>)).MakeGeneric(typeRef);
            }

            return typeRef;
        }

        private class EmojiResponse
        {
            public string Name { get; set; }
            public string Moji { get; set; }
            public string Shortname { get; set; }
        }
    }
}
