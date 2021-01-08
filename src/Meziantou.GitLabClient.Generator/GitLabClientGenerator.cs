﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Meziantou.Framework;
using Meziantou.Framework.CodeDom;
using Meziantou.GitLabClient.Generator.Internals;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed partial class GitLabClientGenerator
    {
        private const string RootNamespace = "Meziantou.GitLab";
        private const string InternalsNamespace = "Meziantou.GitLab.Internals";
        private const string SerializationNamespace = "Meziantou.GitLab.Serialization";

        internal static class WellKnownTypes
        {
            public static TypeReference GitLabExceptionTypeReference { get; } = new(RootNamespace + ".GitLabException");
            public static TypeReference UrlBuilderTypeReference { get; } = new(InternalsNamespace + ".UrlBuilder");
            public static TypeReference PageOptionsTypeReference { get; } = new(RootNamespace + ".PageOptions");
            public static TypeReference HttpResponseStreamTypeReference { get; } = new(RootNamespace + ".HttpResponseStream");
            public static TypeReference HttpResponseTypeReference { get; } = new("HttpResponse");
            public static TypeReference SkipUtcDateValidationAttributeTypeReference { get; } = new(InternalsNamespace + ".SkipUtcDateValidationAttribute");
            public static TypeReference SkipAbsoluteUriValidationAttribute { get; } = new(InternalsNamespace + ".SkipAbsoluteUriValidationAttribute");
            public static TypeReference MappedPropertyAttributeTypeReference { get; } = new(InternalsNamespace + ".MappedPropertyAttribute");
            public static TypeReference IGitLabObjectReferenceTypeReference { get; } = new(InternalsNamespace + ".IGitLabObjectReference");
            public static TypeReference JsonContentTypeReference { get; } = new(InternalsNamespace + ".JsonContent");
            public static TypeReference UnsafeListDictionaryTypeReference { get; } = new(InternalsNamespace + ".UnsafeListDictionary");

            public static TypeReference EnumMemberTypeReference { get; } = new(SerializationNamespace + ".EnumMember");
            public static TypeReference JsonSerializationTypeReference { get; } = new(SerializationNamespace + ".JsonSerialization");
            public static TypeReference GitLabDateJsonConverterTypeReference { get; } = new(SerializationNamespace + ".GitLabDateJsonConverter");
            public static TypeReference GitLabObjectJsonConverterFactoryTypeReference { get; } = new(SerializationNamespace + ".GitLabObjectJsonConverterFactory");
            public static TypeReference GitLabObjectReferenceJsonConverterFactoryTypeReference { get; } = new(SerializationNamespace + ".GitLabObjectReferenceJsonConverterFactory");

            public static TypeReference ArgumentCollectionTypeReference { get; } = new(typeof(IEnumerable<>));
            public static TypeReference PropertyCollectionTypeReference { get; } = new(typeof(IReadOnlyList<>));
        }

        private readonly List<CompilationUnit> _units = new();

        public void Generate(FullPath rootDirectory, Project project)
        {
            GenerateCode(project);
            WriteFiles(rootDirectory);
        }

        private void WriteFiles(FullPath rootDirectory)
        {
            var existingFiles = Directory.GetFiles(rootDirectory, "*.g.cs", SearchOption.AllDirectories).Select(FullPath.FromPath).ToList();

            foreach (var unit in _units)
            {
                var relativePath = (string)unit.Data["FileName"];
                new DefaultFormatterVisitor().Visit(unit);
                var destinationFile = rootDirectory / relativePath;
                unit.WriteUnit(destinationFile);
                existingFiles.Remove(destinationFile);
            }

            foreach (var file in existingFiles)
            {
                File.Delete(file);
            }
        }

        private CompilationUnit CreateUnit(string relativePath)
        {
            var extension = Path.GetExtension(relativePath);
            relativePath = Path.ChangeExtension(relativePath, ".g" + extension);

            var unit = new CompilationUnit
            {
                NullableContext = NullableContext.Enable,
            };
            unit.SetData("FileName", relativePath);

            unit.CommentsBefore.Add("------------------------------------------------------------------------------");
            unit.CommentsBefore.Add("<auto-generated>");
            unit.CommentsBefore.Add("    This code was generated by a tool.");
            unit.CommentsBefore.Add("");
            unit.CommentsBefore.Add("    Changes to this file may cause incorrect behavior and will be lost if");
            unit.CommentsBefore.Add("    the code is regenerated");
            unit.CommentsBefore.Add("</auto-generated>");
            unit.CommentsBefore.Add("------------------------------------------------------------------------------");

            _units.Add(unit);
            return unit;
        }

        private void GenerateCode(Project project)
        {
            GenerateEnumerations(project);
            GenerateEntities(project);
            GenerateParameterEntities(project);
            GenerateClients(project);
        }

        private static void AddDocumentationComments(CodeObject commentable, Documentation documentation, Method method)
        {
            if (documentation != null)
            {
                if (commentable is MethodArgumentDeclaration arg)
                {
                    var declaringMethod = (IXmlCommentable)arg.GetSelfOrParentOfType<MethodDeclaration>() ?? arg.GetSelfOrParentOfType<ConstructorDeclaration>();
                    if (documentation.Summary != null)
                    {
                        declaringMethod.XmlComments.AddParam(arg.Name, documentation.Summary);
                    }
                }
                else if (commentable is IXmlCommentable xmlCommentable)
                {
                    var summary = new XElement(XName.Get("summary"));
                    if (documentation.Summary != null)
                    {
                        summary.Add(new XElement("para", documentation.Summary));
                    }

                    if (documentation.Remark != null)
                    {
                        xmlCommentable.XmlComments.Add(new XElement("remark", documentation.Remark));
                    }

                    if (documentation.Returns != null)
                    {
                        xmlCommentable.XmlComments.AddReturn(documentation.Returns);
                    }

                    if (method?.UrlTemplate != null)
                    {
                        var methodType = method.MethodType switch
                        {
                            MethodType.GetCollection or MethodType.GetPaged => MethodType.Get,
                            _ => method.MethodType,
                        };
                        var urlTempate = methodType.ToString().ToUpperInvariant() + " /" + method.UrlTemplate;
                        summary.Add(new XElement("para", "URL: ", new XElement("c", urlTempate)));
                    }

                    if (documentation.HelpLink != null)
                    {
                        summary.Add(new XElement("para", new XElement("seealso", new XAttribute("href", documentation.HelpLink))));
                    }

                    if (summary.HasElements)
                    {
                        xmlCommentable.XmlComments.Add(summary);
                    }
                }
            }
        }

        private static void AddDocumentationComments(CodeObject commentable, Method method)
        {
            AddDocumentationComments(commentable, method.Documentation, method);
        }

        private static void AddDocumentationComments(CodeObject commentable, Documentation documentation)
        {
            AddDocumentationComments(commentable, documentation, method: null);
        }

        private static string ToFieldName(string value)
        {
            var pascalCase = ToPropertyName(value);
            return "_" + char.ToLowerInvariant(pascalCase[0]) + pascalCase[1..];
        }

        internal static string ToPropertyName(string value)
        {
            return value.Split(new[] { "_", "." }, StringSplitOptions.RemoveEmptyEntries)
             .Select(s => char.ToUpperInvariant(s[0]) + s[1..])
             .Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        private static string ToArgumentName(string value)
        {
            var pascalCase = ToPropertyName(value);
            return char.ToLowerInvariant(pascalCase[0]) + pascalCase[1..];
        }

        private static ParameterLocation GetParameterLocation(Method method, MethodParameter parameter)
        {
            if (parameter.Location != ParameterLocation.Default)
            {
                return parameter.Location;
            }

            if (method.UrlTemplate.Contains($":{parameter.Name}/", StringComparison.Ordinal) || method.UrlTemplate.EndsWith($":{parameter.Name}", StringComparison.Ordinal))
                return ParameterLocation.Url;

            if (method.UrlTemplate.EndsWith($"*{parameter.Name}", StringComparison.Ordinal))
                return ParameterLocation.Url;

            return method.MethodType switch
            {
                MethodType.Get => ParameterLocation.Url,
                MethodType.GetPaged => ParameterLocation.Url,
                MethodType.Put => ParameterLocation.Body,
                MethodType.Post => ParameterLocation.Body,
                MethodType.Delete => ParameterLocation.Body,
                _ => throw new ArgumentOutOfRangeException(nameof(method)),
            };
        }

        private static TypeReference GetPropertyTypeRef(ModelRef modelRef)
        {
            var typeRef = modelRef.ToPropertyTypeReference();
            return typeRef;
        }

        private static TypeReference GetArgumentTypeRef(MethodParameter param)
        {
            var typeRef = param.Type.ToArgumentTypeReference();

            if (!param.IsRequired)
            {
                typeRef = typeRef.MakeNullable();
            }

            return typeRef;
        }
    }
}
