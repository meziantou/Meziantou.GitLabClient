using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab.Internals
{
    internal sealed class DynamicJsonObject : DynamicJsonElement
    {
        internal DynamicJsonObject(JsonElement element, JsonSerializerOptions options)
            : base(element, options)
        {
            if (element.ValueKind != JsonValueKind.Object)
                throw new ArgumentOutOfRangeException(nameof(element));
        }

        public override bool TryConvert(ConvertBinder binder, out object? result)
        {
            if (binder.Type == typeof(JsonElement))
            {
                result = Element;
                return true;
            }

            try
            {
                result = JsonSerialization.ToObject(Element, binder.Type, Options);
                return true;
            }
            catch (JsonException)
            {
            }

            result = null;
            return false;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            foreach (var property in Element.EnumerateObject())
            {
                yield return property.Name;
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object? result)
        {
            if (indexes.Length == 1 && indexes[0] is string propertyName && Element.TryGetProperty(propertyName, out var element))
            {
                result = GetValue(element);
                return true;
            }

            result = null;
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            if (Element.TryGetProperty(binder.Name, out var property))
            {
                result = GetValue(property);
                return true;
            }

            result = null;
            return false;
        }
    }
}
