﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectJsonConverterFactory))]
    public partial class Pipeline : PipelineBasic
    {
        internal Pipeline(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("duration")]
        public System.TimeSpan Duration
        {
            get
            {
                return this.GetRequiredNonNullValue<System.TimeSpan>("duration");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("queue_duration")]
        public System.TimeSpan QueueDuration
        {
            get
            {
                return this.GetRequiredNonNullValue<System.TimeSpan>("queue_duration");
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Design", "MA0075:Do not use implicit culture-sensitive ToString", Justification = "Valid in ToString")]
        public override string ToString()
        {
            return ((("Pipeline { " + "Id = ") + this.Id) + " }");
        }
    }
}
