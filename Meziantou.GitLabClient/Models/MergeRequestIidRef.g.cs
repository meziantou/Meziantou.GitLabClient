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
    public readonly partial struct MergeRequestIidRef : Meziantou.GitLab.IGitLabObjectReference<long>
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

        public static Meziantou.GitLab.MergeRequestIidRef FromInt64(long mergeRequestIid)
        {
            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequestIid);
        }

        public static Meziantou.GitLab.MergeRequestIidRef FromMergeRequest(MergeRequest mergeRequest)
        {
            if ((mergeRequest == null))
            {
                throw new System.ArgumentNullException(nameof(mergeRequest));
            }

            return new Meziantou.GitLab.MergeRequestIidRef(mergeRequest);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(long mergeRequestIid)
        {
            return Meziantou.GitLab.MergeRequestIidRef.FromInt64(mergeRequestIid);
        }

        public static implicit operator Meziantou.GitLab.MergeRequestIidRef(MergeRequest mergeRequest)
        {
            return Meziantou.GitLab.MergeRequestIidRef.FromMergeRequest(mergeRequest);
        }
    }
}
#nullable disable
