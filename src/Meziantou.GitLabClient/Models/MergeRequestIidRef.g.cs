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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectReferenceJsonConverterFactory))]
    public readonly partial struct MergeRequestIidRef : Meziantou.GitLab.Internals.IGitLabObjectReference<long>, System.IEquatable<Meziantou.GitLab.MergeRequestIidRef>
    {
        private readonly long _value;

        private MergeRequestIidRef(long mergeRequestIid)
        {
            this._value = mergeRequestIid;
        }

        private MergeRequestIidRef(MergeRequest mergeRequest)
        {
            if ((mergeRequest == null))
            {
                throw new System.ArgumentNullException(nameof(mergeRequest));
            }

            this._value = mergeRequest.Iid;
        }

        public long Value
        {
            get
            {
                return this._value;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.MergeRequestIidRef))
            {
                return this.Equals(((Meziantou.GitLab.MergeRequestIidRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.MergeRequestIidRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public static Meziantou.GitLab.MergeRequestIidRef FromMergeRequest(MergeRequest mergeRequest)
        {
            if ((mergeRequest == null))
            {
                throw new System.ArgumentNullException(nameof(mergeRequest));
            }

            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequest);
        }

        public static Meziantou.GitLab.MergeRequestIidRef FromMergeRequestIid(long mergeRequestIid)
        {
            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequestIid);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(long mergeRequestIid)
        {
            return Meziantou.GitLab.MergeRequestIidRef.FromMergeRequestIid(mergeRequestIid);
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef?(long? mergeRequestIid)
        {
            if (mergeRequestIid.HasValue)
            {
                return Meziantou.GitLab.MergeRequestIidRef.FromMergeRequestIid(mergeRequestIid.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(MergeRequest mergeRequest)
        {
            return Meziantou.GitLab.MergeRequestIidRef.FromMergeRequest(mergeRequest);
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef?(MergeRequest? mergeRequest)
        {
            if (object.ReferenceEquals(mergeRequest, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.MergeRequestIidRef.FromMergeRequest(mergeRequest);
            }
        }

        public static bool operator !=(Meziantou.GitLab.MergeRequestIidRef a, Meziantou.GitLab.MergeRequestIidRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.MergeRequestIidRef a, Meziantou.GitLab.MergeRequestIidRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.MergeRequestIidRef>.Default.Equals(a, b);
        }
    }
}
