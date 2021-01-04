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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.LicenseJsonConverter))]
    public partial class License : Meziantou.GitLab.Core.GitLabObject
    {
        internal License(System.Text.Json.JsonElement obj)
            : base(obj)
        {
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("active_users")]
        public int ActiveUsers
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("active_users");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("created_at")]
        public System.DateTimeOffset CreatedAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTimeOffset>("created_at");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("expired")]
        public bool Expired
        {
            get
            {
                return this.GetRequiredNonNullValue<bool>("expired");
            }
        }

        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Internals.SkipUtcDateValidationAttribute))]
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("expires_at")]
        public System.DateTime ExpiresAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTime>("expires_at");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("historical_max")]
        public int HistoricalMax
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("historical_max");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("id")]
        public long Id
        {
            get
            {
                return this.GetRequiredNonNullValue<long>("id");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("maximum_user_count")]
        public int MaximumUserCount
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("maximum_user_count");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("overage")]
        public int Overage
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("overage");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("plan")]
        public string Plan
        {
            get
            {
                return this.GetRequiredNonNullValue<string>("plan");
            }
        }

        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Internals.SkipUtcDateValidationAttribute))]
        [Meziantou.GitLab.Internals.MappedPropertyAttribute("starts_at")]
        public System.DateTime StartsAt
        {
            get
            {
                return this.GetRequiredNonNullValue<System.DateTime>("starts_at");
            }
        }

        [Meziantou.GitLab.Internals.MappedPropertyAttribute("user_limit")]
        public int UserLimit
        {
            get
            {
                return this.GetRequiredNonNullValue<int>("user_limit");
            }
        }
    }
}

namespace Meziantou.GitLab.Serialization
{
    internal sealed partial class LicenseJsonConverter : Meziantou.GitLab.Serialization.GitLabObjectBaseJsonConverter<Meziantou.GitLab.License>
    {
        protected override Meziantou.GitLab.License CreateInstance(System.Text.Json.JsonElement jsonElement)
        {
            return new Meziantou.GitLab.License(jsonElement);
        }
    }
}
