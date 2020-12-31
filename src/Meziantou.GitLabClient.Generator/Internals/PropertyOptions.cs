using System;

namespace Meziantou.GitLabClient.Generator
{
    [Flags]
    internal enum PropertyOptions
    {
        None = 0x0,

        /// <summary>
        /// Indicates the property uniquely identify the item in the collection.
        /// This property is used to generate the <see cref="object.Equals(object?)"/> method and <see cref="ParameterEntityRef"/>.
        /// </summary>
        IsKey = 0x1,

        /// <summary>
        /// Indicates the property should be used to generate the <see cref="object.ToString"/> method and <see cref="System.Diagnostics.DebuggerDisplayAttribute"/>.
        /// </summary>
        IsDisplayName = 0x2,

        /// <summary>
        /// For properties of type <see cref="ModelRef.Uri"/>, it indicates the value returns by GitLab could be a relative uri.
        /// </summary>
        CanBeAbsoluteOrRelativeUri = 0x4,

        /// <summary>
        /// For properties of type <see cref="ModelRef.DateTime"/>, it indicates the value returns by GitLab is not a UTC date time.
        /// </summary>
        IsNotUTCDate = 0x8,
    }
}
