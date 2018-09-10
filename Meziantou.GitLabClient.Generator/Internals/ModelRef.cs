using System;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal class ModelRef
    {
        public static ModelRef Object { get; } = new ModelRef(typeof(object));
        public static ModelRef String { get; } = new ModelRef(typeof(string));
        public static ModelRef StringCollection { get; } = new ModelRef(typeof(string)) { IsCollection = true };
        public static ModelRef Int32 { get; } = new ModelRef(typeof(int));
        public static ModelRef NullableInt32 { get; } = new ModelRef(typeof(int)) { IsNullable = true };
        public static ModelRef Int64 { get; } = new ModelRef(typeof(long));
        public static ModelRef NullableInt64 { get; } = new ModelRef(typeof(long)) { IsNullable = true };
        public static ModelRef Boolean { get; } = new ModelRef(typeof(bool));
        public static ModelRef NullableBoolean { get; } = new ModelRef(typeof(bool)) { IsNullable = true };
        public static ModelRef DateTime { get; } = new ModelRef(typeof(DateTime));
        public static ModelRef NullableDateTime { get; } = new ModelRef(typeof(DateTime)) { IsNullable = true };
        public static ModelRef Date { get; } = new ModelRef(typeof(DateTime));
        public static ModelRef NullableDate { get; } = new ModelRef(typeof(DateTime)) { IsNullable = true };
        public static ModelRef GitLabObject { get; } = new ModelRef("GitLab.GitLabObject");
        public static ModelRef RequestOptions { get; } = new ModelRef("GitLab.RequestOptions");

        public static ModelRef Id { get; } = new ModelRef(typeof(long));
        public static ModelRef NullableId { get; } = new ModelRef(typeof(long)) { IsNullable = true };

        public Type Type { get; }
        public Model Model { get; }
        public ParameterEntity ParameterEntity { get; }
        public string TypeName { get; }

        public bool IsNullable { get; set; }
        public bool IsCollection { get; set; }

        public bool IsParameterEntity => ParameterEntity != null;
        public bool IsModel => Model != null;

        public ModelRef(string typeName)
        {
            TypeName = typeName;
        }

        public ModelRef(Type type)
        {
            Type = type;
        }

        public ModelRef(Model model)
        {
            Model = model;
        }

        public ModelRef(ParameterEntity model)
        {
            ParameterEntity = model;
        }

        public static implicit operator ModelRef(Model model) => new ModelRef(model);

        public static implicit operator ModelRef(Type type) => new ModelRef(type);

        public static implicit operator ModelRef(ParameterEntity model) => new ModelRef(model);

        public static implicit operator TypeReference(ModelRef modelRef)
        {
            if (modelRef == null)
                return null;

            TypeReference typeRef;
            if (modelRef.Type != null)
            {
                typeRef = new TypeReference(modelRef.Type);
            }
            else if (modelRef.Model != null)
            {
                typeRef = new TypeReference(modelRef.Model.Name);
            }
            else if (modelRef.ParameterEntity != null)
            {
                typeRef = new TypeReference(modelRef.ParameterEntity.Name);
            }
            else
            {
                typeRef = new TypeReference(modelRef.TypeName);
            }

            if (modelRef.IsNullable)
            {
                typeRef = new TypeReference(typeof(Nullable<>)).MakeGeneric(typeRef);
            }

            return typeRef;
        }
    }
}
