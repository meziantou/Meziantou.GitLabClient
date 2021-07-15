using System;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder PipelineVariable { get; } = CreateEntity(entity => entity
                .AddProperty("key", ModelRef.String)
                .AddProperty("value", ModelRef.String)
                .AddProperty("variable_type", Models.PipelineVariableType)
        );
    }
}
