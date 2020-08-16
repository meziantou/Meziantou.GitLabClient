using System;
using Newtonsoft.Json;

namespace Meziantou.GitLab
{
    internal sealed class GitLabObjectReferenceJsonConverter : JsonConverter<IGitLabObjectReference>
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override IGitLabObjectReference ReadJson(JsonReader reader, Type objectType, IGitLabObjectReference existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override void WriteJson(JsonWriter writer, IGitLabObjectReference value, JsonSerializer serializer)
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
    }
}
