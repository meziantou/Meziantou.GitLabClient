using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal class GitLabEnumConverter : JsonConverter
    {
        private static readonly MethodInfo EnumTryParseMethodInfo = GetEnumTryParseMethodInfo();

        private static MethodInfo GetEnumTryParseMethodInfo()
        {
            // Enum.TryParse<T>(string value, bool ignoreCase, out T value)
            return typeof(Enum)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .First(m => m.Name == nameof(Enum.TryParse) && m.IsGenericMethod && m.GetParameters().Length == 3);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum || (IsNullableOfT(objectType) && Nullable.GetUnderlyingType(objectType).IsEnum);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var isNullable = IsNullableOfT(objectType);
            Type t = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            if (reader.Value is string str)
            {
                var mi = EnumTryParseMethodInfo.MakeGenericMethod(t);
                object[] args = { FromSnakeCase(str), true, Enum.ToObject(t, 0) };
                var parsed = (bool)mi.Invoke(null, args);
                if (parsed)
                    return args[2];

                if (t == typeof(ErrorCode) && str == "404 Not Found")
                    return ErrorCode.NotFound;
            }

            throw new ArgumentException($"'{reader.Value}' is not convertible to type '{objectType.FullName}'");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(ToSnakeCase(value.ToString()));
            }
        }

        public override bool CanRead => true;
        public override bool CanWrite => true;

        private static string ToSnakeCase(string value)
        {
            var sb = new StringBuilder(value.Length * 2);
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (c >= 'A' && c <= 'Z')
                {
                    if (sb.Length > 0)
                    {
                        sb.Append('_');
                    }

                    sb.Append(char.ToLowerInvariant(c));
                }
            }

            return sb.ToString();
        }

        private static string FromSnakeCase(string value)
        {
            var sb = new StringBuilder(value.Length);
            bool mustUpperCase = true;
            for (int i = 0; i < value.Length; i++)
            {
                var c = value[i];
                if (c == '_')
                {
                    mustUpperCase = true;
                    continue;
                }

                if (mustUpperCase)
                {
                    sb.Append(char.ToUpperInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private static bool IsNullableOfT(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
