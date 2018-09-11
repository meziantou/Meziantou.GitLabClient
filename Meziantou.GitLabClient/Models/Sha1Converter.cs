using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    public class Sha1Converter : JsonConverter<Sha1>
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override Sha1 ReadJson(JsonReader reader, Type objectType, Sha1 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                if (Sha1.TryParse((string)reader.Value, out var sha1))
                    return sha1;
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, Sha1 value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
