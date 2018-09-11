using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Meziantou.GitLab
{
    public abstract class GitLabObject
    {
        private IDictionary<string, JToken> _additionalData = null;

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData
        {
            get
            {
                if (_additionalData == null)
                {
                    _additionalData = new Dictionary<string, JToken>();
                }

                return _additionalData;
            }
        }

        [JsonIgnore]
        internal IGitLabClient GitLabClient { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (context.Context is IGitLabClient client)
            {
                GitLabClient = client;
            }
        }
    }
}
