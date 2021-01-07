using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab.Internals
{
    internal sealed class DynamicJsonArray : DynamicJsonElement
    {
        internal DynamicJsonArray(JsonElement element, JsonSerializerOptions options)
            : base(element, options)
        {
            if (element.ValueKind != JsonValueKind.Array)
            {
                throw new ArgumentOutOfRangeException(nameof(element));
            }
        }

        public override bool TryConvert(ConvertBinder binder, out object? result)
        {
            if (binder.Type == typeof(JsonElement))
            {
                result = Element;
                return true;
            }

            if (binder.Type.IsArray)
            {
                var elementType = binder.Type.GetElementType();
                Debug.Assert(elementType != null);
                result = ToArray(elementType);
                return true;
            }

            if (binder.Type.IsGenericType && binder.Type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                result = ToArray(binder.Type.GetGenericArguments()[0]);
                return true;
            }

            result = null;
            return false;
        }

        private Array ToArray(Type type)
        {
            var length = Element.GetArrayLength();
            var array = (Array?)Activator.CreateInstance(type.MakeArrayType(), length);
            Debug.Assert(array != null);
            var enumerator = Element.EnumerateArray();
            var index = 0;

            while (enumerator.MoveNext())
            {
                var value = JsonSerialization.ToObject(enumerator.Current, type);
                array.SetValue(value, index++);
            }

            return array;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
        {
            if (indexes.Length == 1 && indexes[0] is int index && Element.GetArrayLength() >= index)
            {
                result = GetValue(Element.EnumerateArray().ElementAt(index));
                return true;
            }

            result = null!;
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            _ = binder ?? throw new ArgumentNullException(nameof(binder));

            var comparer = binder.IgnoreCase
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            if (string.Equals(binder.Name, "Length", comparer) || string.Equals(binder.Name, "Count", comparer))
            {
                result = Element.GetArrayLength();
                return true;
            }

            result = null;
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            _ = binder ?? throw new ArgumentNullException(nameof(binder));

            var comparer = binder.IgnoreCase
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;

            if (string.Equals(binder.Name, "Count", comparer) && binder.CallInfo.ArgumentCount == 0 &&
                (binder.ReturnType == typeof(int) || binder.ReturnType == typeof(object)))
            {
                result = Element.GetArrayLength();
                return true;
            }

            result = null;
            return false;
        }
    }
}
