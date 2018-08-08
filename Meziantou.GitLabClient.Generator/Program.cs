using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.Framework.CodeDom;
using Meziantou.GitLab;
using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().Generate();
        }

        private Project _project = new Project();
        private Model _identityModel;
        private Model _userActivity;
        private Model _userBasicModel;
        private Model _userModel;
        private Model _userSafeModel;
        private Model _userState;
        private Model _userStatus;

        private void CreateModels()
        {
            _userState = _project.AddModel(new Enumeration("UserState")
            {
                Members =
                {
                    new EnumerationMember("Active"),
                    new EnumerationMember("Blocked"),
                }
            });

            _identityModel = _project.AddModel(new Entity("Identity")
            {
                Properties =
                {
                    new EntityProperty("Provider", ModelRef.String),
                    new EntityProperty("ExternUid", ModelRef.String),
                }
            });

            _userSafeModel = _project.AddModel(new Entity("UserSafe")
            {
                Properties =
                {
                    new EntityProperty("Id", ModelRef.Long),
                    new EntityProperty("Name", ModelRef.String),
                    new EntityProperty("Username", ModelRef.String),
                }
            });

            _userBasicModel = _project.AddModel(new Entity("UserBasic")
            {
                BaseType = _userSafeModel,
                Properties =
                {
                    new EntityProperty("AvatarUrl", ModelRef.String),
                    new EntityProperty("AvatarPath", ModelRef.String),
                    new EntityProperty("WebUrl", ModelRef.String),
                }
            });

            _userModel = _project.AddModel(new Entity("User")
            {
                BaseType = _userBasicModel,
                Properties =
                {
                    new EntityProperty("State", _userState),
                    new EntityProperty("CreatedAt", ModelRef.DateTime),
                    new EntityProperty("Bio", ModelRef.String),
                    new EntityProperty("Location", ModelRef.String),
                    new EntityProperty("Skype", ModelRef.String),
                    new EntityProperty("Linkedin", ModelRef.String),
                    new EntityProperty("Twitter", ModelRef.String),
                    new EntityProperty("WebsiteUrl", ModelRef.String),
                    new EntityProperty("Organization", ModelRef.String),
                    new EntityProperty("CurrentSignInAt", ModelRef.NullableDateTime),
                    new EntityProperty("LastSignInAt", ModelRef.NullableDateTime),
                    new EntityProperty("ConfirmedAt", ModelRef.NullableDateTime),
                    new EntityProperty("LastActivityOn", ModelRef.NullableDate),
                    new EntityProperty("Email", ModelRef.String),
                    new EntityProperty("ThemeId", ModelRef.Long),
                    new EntityProperty("ColorSchemeId", ModelRef.Long),
                    new EntityProperty("ProjectsLimit", ModelRef.Long),
                    new EntityProperty("Identities", new ModelRef(_identityModel) { IsCollection = true }),
                    new EntityProperty("CanCreateGroup", ModelRef.Boolean),
                    new EntityProperty("CanCreateProject", ModelRef.Boolean),
                    new EntityProperty("TwoFactorEnabled", ModelRef.Boolean),
                    new EntityProperty("External", ModelRef.Boolean),
                    new EntityProperty("PrivateProfile", ModelRef.Object),
                    new EntityProperty("SharedRunnersMinutesLimit", ModelRef.NullableLong),
                    new EntityProperty("IsAdmin", ModelRef.Boolean),
                }
            });

            _userStatus = _project.AddModel(new Entity("UserStatus")
            {
                Properties =
                {
                    new EntityProperty("Emoji", ModelRef.String),
                    new EntityProperty("Message", ModelRef.String),
                    new EntityProperty("MessageHtml", ModelRef.String),
                }
            });

            _userActivity = _project.AddModel(new Entity("UserActivity")
            {
                Properties =
                {
                    new EntityProperty("Username", ModelRef.String),
                    new EntityProperty("LastActivityOn", ModelRef.Date),
                }
            });
        }

        private void CreateMethods()
        {
            _project.AddMethod(new Method
            {
                Name = "GetUser",
                UrlTemplate = "user",
                ReturnType = _userModel,
            });
        }

        public void Generate()
        {
            CreateModels();
            CreateMethods();

            var unit = new CompilationUnit();
            var ns = unit.AddNamespace("Meziantou.GitLab");
            foreach (var model in _project.Models)
            {
                GenerateModel(ns, model);
            }

            var clientClass = ns.AddType(new ClassDeclaration("GitLabClient") { Modifiers = Modifiers.Partial });
            foreach (var method in _project.Methods)
            {
                GenerateMethod(clientClass, method);
            }

            using (var tw = new StreamWriter("../../../../Meziantou.GitLabClient/gitlab.generated.cs"))
            {
                new CSharpCodeGenerator().Write(tw, unit);
            }
        }

        private static void GenerateMethod(ClassDeclaration clientClass, Method method)
        {
            var m = clientClass.AddMember(new MethodDeclaration(method.Name));

            // Method signature
            m.Modifiers = Modifiers.Public;
            if (method.IsPaged)
            {
                m.ReturnType = new TypeReference(typeof(Task)) { Parameters = { new TypeReference("Meziantou.GitLab.PagedResponse<" + method.ReturnType + ">") } };
            }
            else
            {
                m.ReturnType = new TypeReference(typeof(Task)) { Parameters = { method.ReturnType } };
            }

            var arguments = new Dictionary<MethodParameter, MethodArgumentDeclaration>();
            foreach (var param in method.Parameters)
            {
                arguments.Add(param, m.AddArgument(new MethodArgumentDeclaration(param.Type, param.Name)));
            }

            var cancellationTokenArgument = m.AddArgument(new MethodArgumentDeclaration(typeof(CancellationToken), "cancellationToken") { DefaultValue = new DefaultValueExpression(typeof(CancellationToken)) });

            // Method body
            m.Statements = new StatementCollection();

            var urlBuilder = new VariableDeclarationStatement(
                typeof(UrlBuilder), "urlBuilder",
                new TypeReference(typeof(UrlBuilder)).InvokeMethod("Get", method.UrlTemplate));
            m.Statements.Add(urlBuilder);

            foreach (var param in method.Parameters.Where(p => p.Location == ParameterLocation.Url))
            {
                m.Statements.Add(urlBuilder.InvokeMethod(nameof(UrlBuilder.WithValue), param.Name, arguments[param]));
            }

            var url = new VariableDeclarationStatement(typeof(string), "url",
                urlBuilder.InvokeMethod(nameof(UrlBuilder.Build)));
            m.Statements.Add(url);

            if (method.HttpMethod == HttpMethod.Get)
            {
                var invoke = (MethodInvokeExpression)new ThisExpression().InvokeMethod("GetAsync", url, cancellationTokenArgument);
                invoke.Parameters.Add(method.ReturnType);
                m.Statements.Add(new ReturnStatement(invoke));
            }
            else
            {
                throw new NotSupportedException($"Method {method.HttpMethod} is not supported");
            }
        }

        private void GenerateModel(NamespaceDeclaration ns, Model model)
        {
            if (model is Entity entity)
            {
                var type = ns.AddType(new ClassDeclaration(entity.Name));
                type.Modifiers = Modifiers.Public | Modifiers.Partial;
                type.BaseType = entity.BaseType ?? ModelRef.GitLabObject;
                foreach (var prop in entity.Properties)
                {
                    var field = type.AddMember(new FieldDeclaration(ToFieldName(prop.Name), prop.Type, Modifiers.Private));
                    var propertyMember = type.AddMember(new PropertyDeclaration(prop.Name, prop.Type)
                    {
                        Modifiers = Modifiers.Public,
                        Getter = new ReturnStatement(field),
                        Setter = new PropertyMemberDeclaration
                        {
                            Modifiers = Modifiers.Private,
                            Statements = new AssignStatement(field, new ValueArgumentExpression())
                        },
                    });

                    if (prop.Type == ModelRef.Date || prop.Type == ModelRef.NullableDate)
                    {
                        propertyMember.CustomAttributes.Add(new CustomAttribute(typeof(SkipUtcDateValidationAttribute)) { Arguments = { new CustomAttributeArgument("Does not contain time nor timezone (e.g. 2018-01-01)") } });
                    }

                    // [Newtonsoft.Json.JsonProperty(PropertyName = "")]
                    propertyMember.CustomAttributes.Add(new CustomAttribute(typeof(JsonPropertyAttribute))
                    {
                        Arguments = { new CustomAttributeArgument(nameof(JsonPropertyAttribute.PropertyName), ToSnakeCase(prop.Name)) }
                    });
                }
            }
            else if (model is Enumeration enumeration)
            {
                var type = ns.AddType(new EnumerationDeclaration(enumeration.Name));
                type.Modifiers = Modifiers.Public;
                type.BaseType = enumeration.BaseType;
                foreach (var prop in enumeration.Members)
                {
                    type.Members.Add(new Framework.CodeDom.EnumerationMember(prop.Name)
                    {
                        CustomAttributes =
                        {
                            new CustomAttribute(typeof(EnumMemberAttribute)) { Arguments = { new CustomAttributeArgument(nameof(EnumMemberAttribute.Value), ToSnakeCase(prop.Name)) } }
                        }
                    });
                }
            }
        }

        private string ToFieldName(string value)
        {
            return "_" + char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        private string ToSnakeCase(string value)
        {
            return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
