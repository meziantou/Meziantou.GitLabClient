using System;
using System.Collections.Generic;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ModelRef : IEquatable<ModelRef>
    {
        public static ModelRef Object { get; } = new ModelRef(typeof(object));
        public static ModelRef Uri { get; } = new ModelRef(typeof(Uri));
        public static ModelRef NullableUri { get; } = new ModelRef(typeof(Uri)).MakeNullable();
        public static ModelRef String { get; } = new ModelRef(typeof(string));
        public static ModelRef NullableString { get; } = new ModelRef(typeof(string)).MakeNullable();
        public static ModelRef StringCollection { get; } = new ModelRef(typeof(string)).MakeCollection();
        public static ModelRef Number { get; } = new ModelRef(typeof(int));
        public static ModelRef NullableNumber { get; } = new ModelRef(typeof(int)).MakeNullable();
        public static ModelRef Boolean { get; } = new ModelRef(typeof(bool));
        public static ModelRef NullableBoolean { get; } = new ModelRef(typeof(bool)).MakeNullable();
        public static ModelRef DateTime { get; } = new ModelRef(typeof(DateTimeOffset));
        public static ModelRef NullableDateTime { get; } = new ModelRef(typeof(DateTimeOffset)).MakeNullable();
        public static ModelRef Date { get; } = new ModelRef(typeof(DateTime));
        public static ModelRef NullableDate { get; } = new ModelRef(typeof(DateTime)).MakeNullable();
        public static ModelRef GitLabObject { get; } = new ModelRef("Meziantou.GitLab.Core.GitLabObject");
        public static ModelRef RequestOptions { get; } = new ModelRef("Meziantou.GitLab.RequestOptions");
        public static ModelRef GitObjectId { get; } = new ModelRef("Meziantou.GitLab.GitObjectId");
        public static ModelRef NullableGitObjectId { get; } = new ModelRef("Meziantou.GitLab.GitObjectId").MakeNullable();
        public static ModelRef PathWithNamespace { get; } = new ModelRef("Meziantou.GitLab.PathWithNamespace");
        public static ModelRef NumberId { get; } = new ModelRef(typeof(long));
        public static ModelRef NullableNumberId { get; } = new ModelRef(typeof(long)).MakeNullable();

        public ModelRef MakeNullable() => new(this) { IsNullable = true };
        public ModelRef MakeCollection() => new(this) { IsCollection = true };
        public ModelRef MakeCollectionNullable() => new(this) { IsCollection = true, IsCollectionNullable = true };

        public Type Type { get; }
        public Model Model { get; }
        public ParameterEntity ParameterEntity { get; }
        public string TypeName { get; }

        public bool IsNullable { get; private set; }
        public bool IsCollection { get; private set; }
        public bool IsCollectionNullable { get; private set; }

        public bool IsParameterEntity => ParameterEntity != null;
        public bool IsModel => Model != null;

        private string ClrFullTypeName => ToTypeReference(typeof(IEnumerable<>)).ClrFullTypeName;

        public bool IsValueType
        {
            get
            {
                if (Type != null)
                    return Type.IsValueType;

                if (IsParameterEntity)
                    return true;

                if (Model is Enumeration)
                    return true;

                if (Equals(PathWithNamespace))
                    return true;

                if (Equals(GitObjectId))
                    return true;

                return false;
            }
        }

        private ModelRef(string typeName)
        {
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
        }

        private ModelRef(Type type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        private ModelRef(Model model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        private ModelRef(ParameterEntity model)
        {
            ParameterEntity = model ?? throw new ArgumentNullException(nameof(model));
        }

        private ModelRef(ModelRef modelRef)
        {
            Type = modelRef.Type;
            Model = modelRef.Model;
            ParameterEntity = modelRef.ParameterEntity;
            TypeName = modelRef.TypeName;
            IsNullable = modelRef.IsNullable;
            IsCollection = modelRef.IsCollection;
        }

        public static implicit operator ModelRef(Model model) => new(model);
        public static implicit operator ModelRef(EntityBuilder model) => model.Value;
        public static implicit operator ModelRef(ParameterEntity model) => new(model);

        public static bool operator ==(ModelRef left, ModelRef right) => EqualityComparer<ModelRef>.Default.Equals(left, right);

        public static bool operator !=(ModelRef left, ModelRef right) => !(left == right);

        public TypeReference ToPropertyTypeReference()
        {
            return ToTypeReference(new TypeReference(typeof(IReadOnlyList<>)));
        }

        public TypeReference ToArgumentTypeReference()
        {
            return ToTypeReference(new TypeReference(typeof(IEnumerable<>)));
        }

        private TypeReference ToTypeReference(TypeReference collectionType)
        {
            TypeReference typeRef;
            if (Type != null)
            {
                typeRef = new TypeReference(Type);
            }
            else if (Model != null)
            {
                typeRef = new TypeReference(Model.Name);
            }
            else if (ParameterEntity != null)
            {
                typeRef = new TypeReference(ParameterEntity.Name);
            }
            else
            {
                typeRef = new TypeReference(TypeName);
            }

            if (IsNullable)
            {
                typeRef = typeRef.MakeNullable();
            }

            if (IsCollection)
            {
                typeRef = collectionType.MakeGeneric(typeRef);
                if (IsCollectionNullable)
                {
                    typeRef = typeRef.MakeNullable();
                }
            }

            return typeRef;
        }

        public override string ToString()
        {
            return ClrFullTypeName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ModelRef);
        }

        public bool Equals(ModelRef other)
        {
            return other != null &&
                   ClrFullTypeName == other.ClrFullTypeName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ClrFullTypeName);
        }
    }
}
