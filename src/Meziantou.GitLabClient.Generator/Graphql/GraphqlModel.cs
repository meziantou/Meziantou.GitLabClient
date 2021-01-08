using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Meziantou.Framework;

namespace Meziantou.GitLabClient.Generator.Graphql
{
    public class GraphqlModel
    {
        [JsonPropertyName("queryType")]
        public GraphqlTypeRef QueryType { get; set; }

        [JsonPropertyName("mutationType")]
        public GraphqlTypeRef MutationType { get; set; }

        [JsonPropertyName("subscriptionType")]
        public GraphqlTypeRef SubscriptionType { get; set; }

        [JsonPropertyName("types")]
        public IReadOnlyCollection<GraphqlType> Types { get; set; }

        public static async Task<GraphqlModel> GetAsync(bool noCache)
        {
            var path = FullPath.GetTempPath() / "gitlab-gen" / "cache" / "graphql" / "model.graphql";
            if (!noCache && File.Exists(path))
            {
                var text = await File.ReadAllTextAsync(path);
                return JsonSerializer.Deserialize<GraphqlResponse<GraphqlSchemaResponse>>(text).Data.Schema;
            }

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsJsonAsync("https://gitlab.com/api/graphql", new
            {
                operationName = "IntrospectionQuery",
                query = @"
query IntrospectionQuery {
  __schema {
    queryType {
      name
    }
    mutationType {
      name
    }
    subscriptionType {
      name
    }
    types {
      ...FullType
    }
    directives {
      name
      description
      locations
      args {
        ...InputValue
      }
    }
  }
}

fragment FullType on __Type {
  kind
  name
  description
  fields(includeDeprecated: true) {
    name
    description
    args {
      ...InputValue
    }
    type {
      ...TypeRef
    }
    isDeprecated
    deprecationReason
  }
  inputFields {
    ...InputValue
  }
  interfaces {
    ...TypeRef
  }
  enumValues(includeDeprecated: true) {
    name
    description
    isDeprecated
    deprecationReason
  }
  possibleTypes {
    ...TypeRef
  }
}

fragment InputValue on __InputValue {
  name
  description
  type {
    ...TypeRef
  }
  defaultValue
}

fragment TypeRef on __Type {
  kind
  name
  ofType {
    kind
    name
    ofType {
      kind
      name
      ofType {
        kind
        name
        ofType {
          kind
          name
          ofType {
            kind
            name
            ofType {
              kind
              name
            }
          }
        }
      }
    }
  }
}
",
            });
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<GraphqlResponse<GraphqlSchemaResponse>>();

            IOUtilities.PathCreateDirectory(path);
            await File.WriteAllTextAsync(path, JsonSerializer.Serialize(json));
            return json.Data.Schema;
        }

        public GraphqlType GetTypeByName(string name)
        {
            return Types.FirstOrDefault(type => type.Name == name);
        }

        private sealed class GraphqlResponse<T>
        {
            [JsonPropertyName("data")]
            public T Data { get; set; }
        }

        private sealed class GraphqlSchemaResponse
        {
            [JsonPropertyName("__schema")]
            public GraphqlModel Schema { get; set; }
        }
    }

    [DebuggerDisplay("{Kind} {Name}")]
    public class GraphqlTypeRef
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ofType")]
        public GraphqlTypeRef OfType { get; set; }
    }

    [DebuggerDisplay("{Kind} {Name}")]
    public class GraphqlType
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("fields")]
        public IReadOnlyCollection<GraphqlField> Fields { get; set; }

        [JsonPropertyName("inputFields")]
        public IReadOnlyCollection<GraphqlInputValue> InputFields { get; set; }

        [JsonPropertyName("interfaces")]
        public IReadOnlyCollection<GraphqlTypeRef> Interfaces { get; set; }

        [JsonPropertyName("enumValues")]
        public IReadOnlyCollection<GraphqlEnumValue> EnumValues { get; set; }

        [JsonPropertyName("possibleTypes")]
        public IReadOnlyCollection<GraphqlTypeRef> PossibleTypes { get; set; }
    }

    [DebuggerDisplay("Field: {Name}")]
    public class GraphqlField
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("deprecationReason")]
        public string DeprecationReason { get; set; }

        [JsonPropertyName("isDeprecated")]
        public bool IsDeprecated { get; set; }

        [JsonPropertyName("args")]
        public IReadOnlyCollection<GraphqlInputValue> Args { get; set; }

        [JsonPropertyName("type")]
        public GraphqlTypeRef Type { get; set; }
    }

    [DebuggerDisplay("Input: {Name}")]
    public class GraphqlInputValue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("type")]
        public GraphqlTypeRef Type { get; set; }

        [JsonPropertyName("defaultValue")]
        public object DefaultValue { get; set; }
    }

    [DebuggerDisplay("Enum {Name}")]
    public class GraphqlEnumValue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("deprecationReason")]
        public string DeprecationReason { get; set; }
    }
}
