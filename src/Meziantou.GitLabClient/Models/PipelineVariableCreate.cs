using System.Text.Json.Serialization;

namespace Meziantou.GitLab
{
    public sealed class PipelineVariableCreate
    {
        public PipelineVariableCreate(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("value")]
        public string Value { get; }
    }
}
