using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class GitLabClientGenerator
    {
        private void GenerateEntities(Project project)
        {
            foreach (var model in project.Models.OfType<Entity>().OrderBy(m => m.Name))
            {
                var children = new List<Entity>();
                if (model.BaseType == null)
                {
                    FindChildren(children, project.Models.OfType<Entity>(), model);
                }

                GenerateEntity(model, children);

                static void FindChildren(List<Entity> children, IEnumerable<Entity> entities, Entity entity)
                {
                    foreach (var e in entities.Where(e => e.BaseType != null && e.BaseType.IsModel && e.BaseType.Model == entity))
                    {
                        children.Add(e);
                        FindChildren(children, entities, e);
                    }
                }
            }
        }

        private void GenerateEntity(Entity entity, List<Entity> children)
        {
            var unit = CreateUnit("Models/" + entity.Name + ".cs");
            var ns = unit.AddNamespace(RootNamespace);

            var type = ns.AddType(new ClassDeclaration(entity.Name));
            AddDocumentationComments(type, entity.Documentation);
            type.Modifiers = Modifiers.Public | Modifiers.Partial;
            type.BaseType = (entity.BaseType ?? ModelRef.GitLabObject).ToPropertyTypeReference();

            GenerateEntityJsonConverter(entity, unit, type);

            // Add default constructor
            var ctor = type.AddMember(new ConstructorDeclaration()
            {
                Arguments =
                {
                    new MethodArgumentDeclaration(typeof(JsonElement), "obj"),
                },
                Modifiers = Modifiers.Internal,
                Initializer = new ConstructorBaseInitializer(new ArgumentReferenceExpression("obj")),
            });

            // Add properties
            foreach (var prop in entity.Properties)
            {
                var propertyType = GetPropertyTypeRef(prop.Type);

                var propertyMember = type.AddMember(new PropertyDeclaration(ToPropertyName(prop.Name), propertyType)
                {
                    Modifiers = Modifiers.Public,
                });

                if ((!prop.Type.IsCollection && prop.Type.IsNullable) || (prop.Type.IsCollection && prop.Type.IsCollectionNullable))
                {
                    propertyMember.Getter = new StatementCollection
                    {
                        new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("GetValueOrDefault",
                            new TypeReference[]
                            {
                                GetPropertyTypeRef(prop.Type),
                            },
                            new Expression[]
                            {
                                prop.Name,
                                new DefaultValueExpression(GetPropertyTypeRef(prop.Type)),
                            })),
                    };
                }
                else
                {
                    propertyMember.Getter = new StatementCollection
                    {
                        new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("GetRequiredNonNullValue",
                        new TypeReference[]
                        {
                            GetPropertyTypeRef(prop.Type),
                        },
                        new Expression[]
                        {
                            prop.Name,
                        })),
                    };
                }

                AddDocumentationComments(propertyMember, prop.Documentation);

                if (prop.Options.HasFlag(PropertyOptions.IsNotUTCDate))
                {
                    propertyMember.CustomAttributes.Add(new CustomAttribute(WellKnownTypes.SkipUtcDateValidationAttributeTypeReference));
                }

                if (prop.Options.HasFlag(PropertyOptions.CanBeAbsoluteOrRelativeUri))
                {
                    propertyMember.CustomAttributes.Add(new CustomAttribute(WellKnownTypes.SkipAbsoluteUriValidationAttribute));
                }

                propertyMember.CustomAttributes.Add(new CustomAttribute(WellKnownTypes.MappedPropertyAttributeTypeReference) { Arguments = { new CustomAttributeArgument(prop.Name) } });
            }

            // Generate Equals members (Equals, GetHashCode, ==, !=, IEquatable<T>)
            var displayProperty = entity.Properties.FirstOrDefault(p => p.IsDisplayName);
            var keyProperties = entity.Properties.Where(p => p.IsKey).ToList();
            if (keyProperties.Count > 0)
            {
                type.Implements.Add(new TypeReference(typeof(IEquatable<>)).MakeGeneric(type));

                GenerateEntityEqualMethod(type);
                GenerateEntityEqualTypedMethod(type, keyProperties);
                GenerateEntityGetHashCode(type, keyProperties);
                GenerateEntityEqualityOperators(type);
            }

            // Generate EntityDisplayName (DebuggerDisplay, ToString)
            if (displayProperty != null)
            {
                GenerateEntityDebuggerDisplay(type, displayProperty, keyProperties);
            }

            GenerateEntityAsMethods(type, children);
        }

        private static void GenerateEntityJsonConverter(Entity entity, CompilationUnit unit, ClassDeclaration type)
        {
            var ns = unit.AddNamespace(SerializationNamespace);
            var converterType = ns.AddType(new ClassDeclaration(entity.Name + "JsonConverter"));
            converterType.BaseType = new TypeReference("Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter").MakeGeneric(type);
            converterType.Modifiers = Modifiers.Partial | Modifiers.Sealed | Modifiers.Internal;

            var createInstanceMethod = converterType.AddMember(new MethodDeclaration("CreateInstance"));
            createInstanceMethod.Modifiers = Modifiers.Protected | Modifiers.Override;
            createInstanceMethod.ReturnType = type;
            var objArg = createInstanceMethod.AddArgument("jsonElement", typeof(JsonElement));
            createInstanceMethod.Statements = new StatementCollection
                {
                    new ReturnStatement(new NewObjectExpression(type, objArg)),
                };

            type.CustomAttributes.Add(new CustomAttribute(typeof(JsonConverterAttribute))
            {
                Arguments = { new CustomAttributeArgument(new TypeOfExpression(converterType)) },
            });
        }

        private static void GenerateEntityDebuggerDisplay(ClassDeclaration type, EntityProperty displayProperty, List<EntityProperty> keyProperties)
        {
            var properties = new[] { displayProperty }.Concat(keyProperties).Where(p => p != null);

            type.CustomAttributes.Add(new CustomAttribute(typeof(DebuggerDisplayAttribute))
            {
                Arguments =
                    {
                        new CustomAttributeArgument(new LiteralExpression("{GetType().Name,nq} " + string.Join(", ", properties.Select(v=>$"{ToPropertyName(v.Name)}={{{ToPropertyName(v.Name)}}}")))),
                    },
            });
        }

        private static void GenerateEntityEqualityOperators(ClassDeclaration type)
        {
            var equal = type.AddMember(new OperatorDeclaration("=="));
            equal.Modifiers = Modifiers.Public | Modifiers.Static;
            equal.ReturnType = typeof(bool);
            equal.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type).MakeNullable(), "a"));
            equal.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type).MakeNullable(), "b"));
            equal.Statements.Add(new ReturnStatement(new TypeReferenceExpression(new TypeReference(typeof(EqualityComparer<>)).MakeGeneric(type)).CreateMemberReferenceExpression("Default").CreateInvokeMethodExpression("Equals",
                new ArgumentReferenceExpression("a"),
                new ArgumentReferenceExpression("b"))));

            var notEqual = type.AddMember(new OperatorDeclaration("!="));
            notEqual.Modifiers = Modifiers.Public | Modifiers.Static;
            notEqual.ReturnType = typeof(bool);
            notEqual.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type).MakeNullable(), "a"));
            notEqual.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type).MakeNullable(), "b"));
            notEqual.Statements.Add(new ReturnStatement(new UnaryExpression(UnaryOperator.Not, new BinaryExpression(BinaryOperator.Equals, new ArgumentReferenceExpression("a"), new ArgumentReferenceExpression("b")))));
        }

        private static void GenerateEntityGetHashCode(ClassDeclaration type, List<EntityProperty> keyProperties)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.GetHashCode)));
            equal.Modifiers = Modifiers.Public | Modifiers.Override;
            equal.ReturnType = typeof(int);

            var statements = new StatementCollection();
            var expressions = new List<Expression>();

            foreach (var key in keyProperties)
            {
                expressions.Add(new ThisExpression().CreateMemberReferenceExpression(ToPropertyName(key.Name)));
            }

            statements.Add(new ReturnStatement(
                new MethodInvokeExpression(
                    new MemberReferenceExpression(new TypeReferenceExpression(typeof(HashCode)), nameof(HashCode.Combine)),
                    expressions.ToArray())));

            equal.Statements = statements;
        }

        private static void GenerateEntityEqualTypedMethod(ClassDeclaration type, List<EntityProperty> keyProperties)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.Equals)));
            equal.Modifiers = Modifiers.Public | Modifiers.Virtual;
            equal.ReturnType = typeof(bool);
            var objArg = equal.AddArgument("other", new TypeReference(type).MakeNullable());

            Expression returnExpression = new UnaryExpression(
                UnaryOperator.Not,
                new MethodInvokeExpression(
                    new MemberReferenceExpression(typeof(object), nameof(object.ReferenceEquals)),
                    objArg,
                    LiteralExpression.Null()));

            foreach (var key in keyProperties)
            {
                var typeRef = GetPropertyTypeRef(key.Type);
                var expr = new BinaryExpression(BinaryOperator.Equals,
                    new ThisExpression().CreateMemberReferenceExpression(ToPropertyName(key.Name)),
                    objArg.CreateMemberReferenceExpression(ToPropertyName(key.Name)));

                returnExpression = new BinaryExpression(BinaryOperator.And, returnExpression, expr);
            }

            equal.Statements = new ReturnStatement(returnExpression);
        }

        private static void GenerateEntityEqualMethod(ClassDeclaration type)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.Equals)));
            equal.Modifiers = Modifiers.Public | Modifiers.Override;
            equal.ReturnType = typeof(bool);
            var objArg = equal.AddArgument("obj", new TypeReference(typeof(object)).MakeNullable());
            var statements = new StatementCollection();
            equal.Statements = statements;

            statements.Add(new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("Equals", new ConvertExpression(objArg, type))));
        }

        private static void GenerateEntityAsMethods(ClassDeclaration classDeclaration, IEnumerable<Entity> children)
        {
            foreach (var child in children)
            {
                var asMethod = classDeclaration.AddMember(new MethodDeclaration());
                asMethod.Name = "As" + child.Name;
                asMethod.Modifiers = Modifiers.Public;
                asMethod.ReturnType = ((ModelRef)child).ToPropertyTypeReference();
                asMethod.Statements = new ReturnStatement(new NewObjectExpression(asMethod.ReturnType, new MemberReferenceExpression(new ThisExpression(), "JsonObject")));
            }
        }
    }
}
