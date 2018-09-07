using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal class ReferenceJsonConverter : JsonConverter<IReference>
    {
        public override IReference ReadJson(JsonReader reader, Type objectType, IReference existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, IReference value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value.Value);
            }
        }

        public override bool CanRead => false;
        public override bool CanWrite => true;
    }
}
