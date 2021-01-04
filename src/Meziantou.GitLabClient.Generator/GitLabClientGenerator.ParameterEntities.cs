using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class GitLabClientGenerator
    {
        private void GenerateParameterEntities(Project project)
        {
            foreach (var entity in project.ParameterEntities.OrderBy(p => p.Name))
            {
                GenerateParameterEntity(entity);
            }
        }

        private void GenerateParameterEntity(ParameterEntity entity)
        {
            var unit = CreateUnit("Models/" + entity.Name + ".cs");
            var ns = unit.AddNamespace(RootNamespace);
            var type = ns.AddType(new StructDeclaration(entity.Name));
            type.Modifiers = Modifiers.Public | Modifiers.ReadOnly | Modifiers.Partial;

            type.Implements.Add(WellKnownTypes.IGitLabObjectReferenceTypeReference.MakeGeneric(entity.FinalType.ToArgumentTypeReference()));
            type.CustomAttributes.Add(new CustomAttribute(typeof(JsonConverterAttribute))
            {
                Arguments =
                {
                    new CustomAttributeArgument(new TypeOfExpression(WellKnownTypes.GitLabObjectObjectReferenceJsonConverterFactoryTypeReference)),
                },
            });

            // Add Value Property (readonly)
            var valueField = new FieldDeclaration("_value", GetPropertyTypeRef(entity.FinalType), Modifiers.Private | Modifiers.ReadOnly);
            var valueProperty = new PropertyDeclaration("Value", GetPropertyTypeRef(entity.FinalType))
            {
                Modifiers = Modifiers.Public,
                Getter = new PropertyAccessorDeclaration
                {
                    Statements = new ReturnStatement(valueField),
                },
            };

            type.AddMember(valueField);
            type.AddMember(valueProperty);

            foreach (var entityRef in entity.Refs)
            {
                var addNullCheck = entityRef.ModelRef.Model != null;

                // Add constructor
                var ctor = type.AddMember(new ConstructorDeclaration()
                {
                    Modifiers = Modifiers.Private,
                    Arguments =
                    {
                        new MethodArgumentDeclaration(GetPropertyTypeRef(entityRef.ModelRef), entityRef.Name),
                    },
                    Statements =
                    {
                        new AssignStatement(valueField, GetAssignExpression()),
                    },
                });

                if (addNullCheck)
                {
                    ctor.Statements.Insert(0, ctor.Arguments[0].CreateThrowIfNullStatement());
                }

                // FromXXX
                var fromMethod = type.AddMember(new MethodDeclaration()
                {
                    Name = "From" + ToPropertyName(entityRef.Name),
                    Modifiers = Modifiers.Public | Modifiers.Static,
                    ReturnType = type,
                    Arguments =
                    {
                         new MethodArgumentDeclaration(GetPropertyTypeRef(entityRef.ModelRef), entityRef.Name),
                    },
                    Statements = new ReturnStatement(new NewObjectExpression(type, new ArgumentReferenceExpression(entityRef.Name))),
                });

                if (addNullCheck)
                {
                    fromMethod.Statements.Insert(0, fromMethod.Arguments[0].CreateThrowIfNullStatement());
                }

                // Add implicit converter
                type.AddMember(new OperatorDeclaration
                {
                    Modifiers = Modifiers.Public | Modifiers.Static | Modifiers.Implicit,
                    ReturnType = type,
                    Arguments =
                    {
                         new MethodArgumentDeclaration(GetPropertyTypeRef(entityRef.ModelRef), entityRef.Name),
                    },
                    Statements =
                    {
                        new ReturnStatement(new MethodInvokeExpression(new MemberReferenceExpression(type, fromMethod.Name), new ArgumentReferenceExpression(entityRef.Name))),
                    },
                });

                // Add implicit converter nullable
                var nullableImplicitConverter = type.AddMember(new OperatorDeclaration
                {
                    Modifiers = Modifiers.Public | Modifiers.Static | Modifiers.Implicit,
                    ReturnType = new TypeReference(type).MakeNullable(),
                    Arguments =
                    {
                        new MethodArgumentDeclaration(GetPropertyTypeRef(entityRef.ModelRef).MakeNullable(), entityRef.Name),
                    },
                });

                if (entityRef.ModelRef.IsValueType)
                {
                    nullableImplicitConverter.Statements.Add(
                        new ConditionStatement
                        {
                            Condition = new MemberReferenceExpression(new ArgumentReferenceExpression(entityRef.Name), "HasValue"),
                            TrueStatements = new ReturnStatement(
                                new MethodInvokeExpression(
                                    new MemberReferenceExpression(type, fromMethod.Name),
                                    new MemberReferenceExpression(new ArgumentReferenceExpression(entityRef.Name), "Value"))),
                            FalseStatements = new ReturnStatement(LiteralExpression.Null()),
                        });
                }
                else
                {
                    nullableImplicitConverter.Statements.Add(
                        new ConditionStatement
                        {
                            Condition = new MethodInvokeExpression(
                                new MemberReferenceExpression(typeof(object), nameof(object.ReferenceEquals)),
                                new ArgumentReferenceExpression(entityRef.Name),
                                LiteralExpression.Null()),
                            TrueStatements = new ReturnStatement(LiteralExpression.Null()),
                            FalseStatements = new ReturnStatement(new MethodInvokeExpression(new MemberReferenceExpression(type, fromMethod.Name), new ArgumentReferenceExpression(entityRef.Name))),
                        });
                }

                Expression GetAssignExpression()
                {
                    Expression value = new ArgumentReferenceExpression(entityRef.Name);
                    foreach (var member in entityRef.PropertyPath)
                    {
                        value = value.CreateMemberReferenceExpression(ToPropertyName(member));
                    }

                    return value;
                }
            }

            // ToString
            GenerateParameterEntityToString(entity, type, valueProperty);

            // Equals, GetHashCode, ==, !=
            type.Implements.Add(new TypeReference(typeof(IEquatable<>)).MakeGeneric(type));
            GenerateParameterEntityEqualMethod(type);
            GenerateParameterEntityEqualTypedMethod(type, valueProperty);
            GenerateParameterEntityEqualityOperators(type);
            GenerateParameterEntityGetHashCode(type, valueProperty);
        }

        private static void GenerateParameterEntityEqualityOperators(StructDeclaration type)
        {
            var equal = type.AddMember(new OperatorDeclaration("=="));
            equal.Modifiers = Modifiers.Public | Modifiers.Static;
            equal.ReturnType = typeof(bool);
            equal.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type), "a"));
            equal.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type), "b"));
            equal.Statements.Add(new ReturnStatement(new TypeReferenceExpression(new TypeReference(typeof(EqualityComparer<>)).MakeGeneric(type)).CreateMemberReferenceExpression("Default").CreateInvokeMethodExpression("Equals",
                new ArgumentReferenceExpression("a"),
                new ArgumentReferenceExpression("b"))));

            var notEqual = type.AddMember(new OperatorDeclaration("!="));
            notEqual.Modifiers = Modifiers.Public | Modifiers.Static;
            notEqual.ReturnType = typeof(bool);
            notEqual.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type), "a"));
            notEqual.Arguments.Add(new MethodArgumentDeclaration(new TypeReference(type), "b"));
            notEqual.Statements.Add(new ReturnStatement(new UnaryExpression(UnaryOperator.Not, new BinaryExpression(BinaryOperator.Equals, new ArgumentReferenceExpression("a"), new ArgumentReferenceExpression("b")))));
        }

        private static void GenerateParameterEntityGetHashCode(StructDeclaration type, PropertyDeclaration valueProperty)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.GetHashCode)));
            equal.Modifiers = Modifiers.Public | Modifiers.Override;
            equal.ReturnType = typeof(int);

            var statements = new StatementCollection
                {
                    new ReturnStatement(
                        new MethodInvokeExpression(
                            new MemberReferenceExpression(new TypeReferenceExpression(typeof(HashCode)), nameof(HashCode.Combine)),
                            valueProperty)),
                };

            equal.Statements = statements;
        }

        private static void GenerateParameterEntityEqualTypedMethod(StructDeclaration type, PropertyDeclaration valueProperty)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.Equals)));
            equal.Modifiers = Modifiers.Public;
            equal.ReturnType = typeof(bool);
            var objArg = equal.AddArgument("other", new TypeReference(type));

            Expression returnExpression = new MethodInvokeExpression(
                new MemberReferenceExpression(typeof(object), "Equals"),
                valueProperty,
                new MemberReferenceExpression(objArg, valueProperty));

            equal.Statements = new ReturnStatement(returnExpression);
        }

        private static void GenerateParameterEntityEqualMethod(StructDeclaration type)
        {
            var equal = type.AddMember(new MethodDeclaration(nameof(object.Equals)));
            equal.Modifiers = Modifiers.Public | Modifiers.Override;
            equal.ReturnType = typeof(bool);
            var objArg = equal.AddArgument("obj", new TypeReference(typeof(object)).MakeNullable());
            equal.Statements = new StatementCollection()
                {
                    new ConditionStatement
                    {
                        Condition = new IsInstanceOfTypeExpression(objArg, type),
                        TrueStatements = new ReturnStatement(new ThisExpression().CreateInvokeMethodExpression("Equals", new CastExpression(objArg, type))),
                        FalseStatements = new ReturnStatement(LiteralExpression.False()),
                    },
                };
        }

        private static void GenerateParameterEntityToString(ParameterEntity entity, StructDeclaration type, PropertyDeclaration valueProperty)
        {
            var toString = type.AddMember(new MethodDeclaration("ToString"));
            toString.Modifiers = Modifiers.Public | Modifiers.Override;

            toString.ReturnType = typeof(string);

            if (entity.FinalType == ModelRef.NumberId)
            {
                toString.Statements = new ReturnStatement(new MethodInvokeExpression(new MemberReferenceExpression(valueProperty, "ToString"), new MemberReferenceExpression(typeof(CultureInfo), "InvariantCulture")));
            }
            else if (entity.FinalType == ModelRef.String)
            {
                toString.Statements = new ReturnStatement(valueProperty);
            }
            else
            {
                toString.Statements = new ReturnStatement(new MethodInvokeExpression(new MemberReferenceExpression(valueProperty, "ToString")));
            }

            if (entity.FinalType == ModelRef.Object)
            {
                toString.ReturnType = toString.ReturnType.MakeNullable();
            }
        }
    }
}
