using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal partial class GitLabClientGenerator
    {
        private void GenerateEnumerations(Project project)
        {
            foreach (var model in project.Models.OfType<Enumeration>().OrderBy(m => m.Name))
            {
                GenerateEnumeration(model);
            }
        }

        private void GenerateEnumeration(Enumeration enumeration)
        {
            // Create types
            var unit = CreateUnit("Models/" + enumeration.Name + ".cs");
            var ns = unit.AddNamespace(RootNamespace);
            var enumType = ns.AddType(new EnumerationDeclaration(enumeration.Name));
            AddDocumentationComments(enumType, enumeration.Documentation);
            enumType.Modifiers = Modifiers.Public;
            enumType.BaseType = enumeration.BaseType?.ToPropertyTypeReference();

            if (enumeration.IsFlags)
            {
                enumType.CustomAttributes.Add(new CustomAttribute(typeof(FlagsAttribute)));
            }

            // Generate members
            foreach (var member in enumeration.Members)
            {
                var enumerationMember = new Framework.CodeDom.EnumerationMember(ToPropertyName(member.Name));
                enumerationMember.SetData("EnumerationMember", member);
                if (member.Value != null)
                {
                    enumerationMember.Value = new LiteralExpression(member.Value);
                }

                if (enumeration.SerializeAsString)
                {
                    enumerationMember.CustomAttributes.Add(new CustomAttribute(typeof(EnumMemberAttribute))
                    {
                        Arguments = { new CustomAttributeArgument(nameof(EnumMemberAttribute.Value), member.FinalSerializationName) },
                    });
                }

                AddDocumentationComments(enumerationMember, member.Documentation);
                enumType.Members.Add(enumerationMember);
            }

            if (enumeration.GenerateAllMember)
            {
                if (!enumeration.IsFlags)
                    throw new InvalidOperationException($"Cannot generate 'All' member for non-flags enumeration '{enumeration.Name}'");

                Expression initExpression = null;
                foreach (var member in enumType.Members)
                {
                    Expression memberExpression = new TypeReferenceExpression(enumType).CreateMemberReferenceExpression(member.Name);
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
                enumType.Members.Add(enumerationMember);
            }

            if (enumeration.SerializeAsString)
            {
                var converterType = GenerateEnumerationJsonConverter(unit, enumType);
                enumType.CustomAttributes.Add(new CustomAttribute(typeof(JsonConverterAttribute))
                {
                    Arguments = { new CustomAttributeArgument(new TypeOfExpression(converterType)) },
                });
            }

            GenerateEnumerationUrlBuilder(enumeration, unit, enumType);
        }

        private static TypeDeclaration GenerateEnumerationJsonConverter(CompilationUnit unit, EnumerationDeclaration enumType)
        {
            var serializationNamespace = unit.AddNamespace(SerializationNamespace);

            // EnumMembers
            var enumMember = serializationNamespace.AddType(new ClassDeclaration("EnumMember"));
            enumMember.Modifiers = Modifiers.Partial | Modifiers.Internal;

            var enumMemberType = new TypeReference("Meziantou.GitLab.Serialization.EnumMember").MakeGeneric(enumType);
            var arrayType = enumMemberType.Clone();
            arrayType.ArrayRank = 1;

            // EnumMember.Field
            var initArray = enumMember.AddMember(new MethodDeclaration("Create" + enumType.Name + "Members"));
            initArray.Modifiers = Modifiers.Private | Modifiers.Static;
            initArray.ReturnType = arrayType;
            initArray.Statements = new StatementCollection();
            var result = new VariableDeclarationStatement(arrayType, "result", new NewArrayExpression(enumMemberType, enumType.Members.Count));
            initArray.Statements.Add(result);

            for (var i = 0; i < enumType.Members.Count; i++)
            {
                var enumerationMember = enumType.Members[i];
                var model = (EnumerationMember)enumerationMember.Data["EnumerationMember"];
                if (model == null)
                    continue;

                initArray.Statements.Add(new AssignStatement(
                    new ArrayIndexerExpression(result, i),
                    new NewObjectExpression(enumMemberType,
                        new MemberReferenceExpression(new TypeReferenceExpression(enumType), ToPropertyName(enumerationMember.Name)),
                        model.FinalSerializationName)));
            }
            initArray.Statements.Add(new ReturnStatement(result));

            var membersField = enumMember.AddMember(new FieldDeclaration("s" + ToFieldName(enumType.Name) + "Members", arrayType));
            membersField.Modifiers = Modifiers.Private | Modifiers.Static | Modifiers.ReadOnly;
            membersField.InitExpression = new MethodInvokeExpression(new MemberReferenceExpression(new TypeReferenceExpression(enumMember), initArray));

            // EnumMember.FromString
            var fromString = enumMember.AddMember(new MethodDeclaration(enumType.Name + "FromString"));
            var fromStringArg = fromString.AddArgument("value", typeof(string));
            fromString.Modifiers = Modifiers.Public | Modifiers.Static;
            fromString.ReturnType = enumType;
            fromString.Statements = new StatementCollection
                {
                    new ReturnStatement(new MethodInvokeExpression(
                        new MemberReferenceExpression(new TypeReferenceExpression(enumMember), "FromString"),
                        fromStringArg,
                        new MemberReferenceExpression(new TypeReferenceExpression(enumMember), membersField))),
                };

            // EnumMember.ToString
            var toString = enumMember.AddMember(new MethodDeclaration("ToString"));
            var toStringArg = toString.AddArgument("value", enumType);
            toString.Modifiers = Modifiers.Public | Modifiers.Static;
            toString.ReturnType = typeof(string);
            toString.Statements = new StatementCollection();
            foreach (var member in enumType.Members)
            {
                var model = (EnumerationMember)member.Data["EnumerationMember"];
                if (model == null)
                    continue;

                toString.Statements.Add(new ConditionStatement()
                {
                    Condition = new BinaryExpression(BinaryOperator.Equals, toStringArg, new MemberReferenceExpression(new TypeReferenceExpression(enumType), ToPropertyName(member.Name))),
                    TrueStatements = new ReturnStatement(model.FinalSerializationName),
                });
            }

            toString.Statements.Add(new ThrowStatement(
                new NewObjectExpression(typeof(ArgumentOutOfRangeException),
                    new NameofExpression(toStringArg),
                    new MethodInvokeExpression(new MemberReferenceExpression(typeof(string), "Concat"), "Value '", new MethodInvokeExpression(new MemberReferenceExpression(toStringArg, "ToString")), "' is not valid"))));

            // Json converter
            var converterType = serializationNamespace.AddType(new ClassDeclaration(enumType.Name + "JsonConverter"));
            converterType.BaseType = new TypeReference("Meziantou.GitLab.Serialization.EnumBaseJsonConverter").MakeGeneric(enumType);
            converterType.Modifiers = Modifiers.Partial | Modifiers.Sealed | Modifiers.Internal;

            // ToString
            var converterToString = converterType.AddMember(new MethodDeclaration("ToString"));
            converterToString.Modifiers = Modifiers.Protected | Modifiers.Override;
            converterToString.ReturnType = typeof(string);
            var convertToStringArg = converterToString.AddArgument("value", enumType);
            converterToString.Statements =
                new ReturnStatement(
                    new MethodInvokeExpression(
                        new MemberReferenceExpression(new TypeReferenceExpression(enumMember), "ToString"),
                        convertToStringArg));

            // FromString
            var converterFromString = converterType.AddMember(new MethodDeclaration("FromString"));
            converterFromString.Modifiers = Modifiers.Protected | Modifiers.Override;
            converterFromString.ReturnType = enumType;
            var convertFromStringArg = converterFromString.AddArgument("value", typeof(string));
            converterFromString.Statements =
                new ReturnStatement(
                    new MethodInvokeExpression(
                        new MemberReferenceExpression(new TypeReferenceExpression(enumMember), enumType.Name + "FromString"),
                        convertFromStringArg));

            return converterType;
        }

        private static void GenerateEnumerationUrlBuilder(Enumeration enumeration, CompilationUnit unit, TypeReference enumType)
        {
            var ns = unit.AddNamespace(InternalsNamespace);
            var urlBuilder = ns.AddType(new StructDeclaration("UrlBuilder"));
            urlBuilder.Modifiers = Modifiers.Partial | Modifiers.Internal;

            // not nullable
            {
                var method = urlBuilder.AddMember(new MethodDeclaration("AppendParameter"));
                var valueArg = method.AddArgument("value", enumType);
                method.Modifiers = Modifiers.Public;
                method.Statements = new StatementCollection();

                if (enumeration.SerializeAsString)
                {
                    var stringValue = new MethodInvokeExpression(
                        new MemberReferenceExpression(new TypeReference(SerializationNamespace + ".EnumMember"), "ToString"),
                        valueArg);

                    // Could be Append (without escaping) if all names are valid in URL
                    var methodName = "AppendParameter";
                    if (enumeration.Members.All(m => m.FinalSerializationName == Uri.EscapeDataString(m.FinalSerializationName)))
                    {
                        methodName = "Append";
                    }
                    method.Statements.Add(new MethodInvokeExpression(new MemberReferenceExpression(new ThisExpression(), methodName), stringValue));
                }
                else
                {
                    method.Statements.Add(new MethodInvokeExpression(new MemberReferenceExpression(new ThisExpression(), "AppendParameter"),
                        new CastExpression(valueArg, typeof(int))));
                }
            }
        }
    }
}
