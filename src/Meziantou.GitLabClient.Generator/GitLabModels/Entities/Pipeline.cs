using System;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    partial class Models
    {
        public static EntityBuilder Pipeline { get; } = CreateEntity(entity => entity
                .WithBaseType(PipelineBasic)
                .AddProperty("duration", ModelRef.Duration)
                .AddProperty("queue_duration", ModelRef.Duration)
        );
    }
}
