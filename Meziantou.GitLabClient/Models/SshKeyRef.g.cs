// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectInt64ReferenceJsonConverter))]
    public readonly partial struct SshKeyRef : Meziantou.GitLab.IGitLabObjectReference<long>, System.IEquatable<Meziantou.GitLab.SshKeyRef>
    {
        private readonly long _value;

        private SshKeyRef(long sshKeyId)
        {
            this._value = sshKeyId;
        }

        private SshKeyRef(SshKey sskKey)
        {
            if ((sskKey == null))
            {
                throw new System.ArgumentNullException(nameof(sskKey));
            }

            this._value = sskKey.Id;
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
            if ((obj is Meziantou.GitLab.SshKeyRef))
            {
                return this.Equals(((Meziantou.GitLab.SshKeyRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.SshKeyRef obj)
        {
            return object.Equals(this.Value, obj.Value);
        }

        public static Meziantou.GitLab.SshKeyRef FromSshKeyId(long sshKeyId)
        {
            return new Meziantou.GitLab.SshKeyRef(sshKeyId);
        }

        public static Meziantou.GitLab.SshKeyRef FromSskKey(SshKey sskKey)
        {
            if ((sskKey == null))
            {
                throw new System.ArgumentNullException(nameof(sskKey));
            }

            return new Meziantou.GitLab.SshKeyRef(sskKey);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(long sshKeyId)
        {
            return Meziantou.GitLab.SshKeyRef.FromSshKeyId(sshKeyId);
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef?(long? sshKeyId)
        {
            if (sshKeyId.HasValue)
            {
                return Meziantou.GitLab.SshKeyRef.FromSshKeyId(sshKeyId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef(SshKey sskKey)
        {
            return Meziantou.GitLab.SshKeyRef.FromSskKey(sskKey);
        }

        public static implicit operator Meziantou.GitLab.SshKeyRef?(SshKey? sskKey)
        {
            if (object.ReferenceEquals(sskKey, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.SshKeyRef.FromSskKey(sskKey);
            }
        }

        public static bool operator !=(Meziantou.GitLab.SshKeyRef a, Meziantou.GitLab.SshKeyRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.SshKeyRef a, Meziantou.GitLab.SshKeyRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.SshKeyRef>.Default.Equals(a, b);
        }
    }
}
