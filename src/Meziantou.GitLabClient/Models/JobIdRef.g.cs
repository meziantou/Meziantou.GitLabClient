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
    public readonly partial struct JobIdRef : Meziantou.GitLab.Internals.IGitLabObjectReference<long>, System.IEquatable<Meziantou.GitLab.JobIdRef>
    {
        private readonly long _value;

        private JobIdRef(long jobId)
        {
            this._value = jobId;
        }

        private JobIdRef(Job job)
        {
            if ((job == null))
            {
                throw new System.ArgumentNullException(nameof(job));
            }

            this._value = job.Id;
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
            if ((obj is Meziantou.GitLab.JobIdRef))
            {
                return this.Equals(((Meziantou.GitLab.JobIdRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.JobIdRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public static Meziantou.GitLab.JobIdRef FromJob(Job job)
        {
            if ((job == null))
            {
                throw new System.ArgumentNullException(nameof(job));
            }

            return new Meziantou.GitLab.JobIdRef(job);
        }

        public static Meziantou.GitLab.JobIdRef FromJobId(long jobId)
        {
            return new Meziantou.GitLab.JobIdRef(jobId);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static implicit operator Meziantou.GitLab.JobIdRef(long jobId)
        {
            return Meziantou.GitLab.JobIdRef.FromJobId(jobId);
        }

        public static implicit operator Meziantou.GitLab.JobIdRef?(long? jobId)
        {
            if (jobId.HasValue)
            {
                return Meziantou.GitLab.JobIdRef.FromJobId(jobId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.JobIdRef(Job job)
        {
            return Meziantou.GitLab.JobIdRef.FromJob(job);
        }

        public static implicit operator Meziantou.GitLab.JobIdRef?(Job? job)
        {
            if (object.ReferenceEquals(job, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.JobIdRef.FromJob(job);
            }
        }

        public static bool operator !=(Meziantou.GitLab.JobIdRef a, Meziantou.GitLab.JobIdRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.JobIdRef a, Meziantou.GitLab.JobIdRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.JobIdRef>.Default.Equals(a, b);
        }
    }
}
