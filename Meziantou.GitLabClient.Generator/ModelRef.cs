using System;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal class ModelRef
    {
        public static ModelRef Object { get; } = new ModelRef(typeof(object));
        public static ModelRef String { get; } = new ModelRef(typeof(string));
        public static ModelRef Long { get; } = new ModelRef(typeof(long));
        public static ModelRef NullableLong { get; } = new ModelRef(typeof(long)) { IsNullable = true };
        public static ModelRef Boolean { get; } = new ModelRef(typeof(bool));
        public static ModelRef DateTime { get; } = new ModelRef(typeof(DateTime));
        public static ModelRef NullableDateTime { get; } = new ModelRef(typeof(DateTime)) { IsNullable = true };
        public static ModelRef Date { get; } = new ModelRef(typeof(DateTime));
        public static ModelRef NullableDate { get; } = new ModelRef(typeof(DateTime)) { IsNullable = true };
        public static ModelRef GitLabObject { get; } = new ModelRef("GitLabObject");

        public string TypeName { get; }
        public bool IsNullable { get; set; }
        public bool IsCollection { get; set; }

        public ModelRef(string typeName)
        {
            TypeName = typeName;
        }

        public ModelRef(Type type)
        {
            TypeName = type.FullName;
        }

        public ModelRef(Model model)
        {
            TypeName = model.Name;
        }

        public static implicit operator ModelRef(Model model)
        {
            return new ModelRef(model.Name);
        }

        public static implicit operator TypeReference(ModelRef modelRef)
        {
            if (modelRef == null)
                return null;

            var typeName = modelRef.TypeName;
            if (modelRef.IsNullable)
            {
                typeName = "System.Nullable<" + typeName + ">";
            }

            if (modelRef.IsCollection)
            {
                typeName = "System.Collections.Generic.IReadOnlyList<" + typeName + ">";
            }

            return new TypeReference(typeName);
        }
    }
}
