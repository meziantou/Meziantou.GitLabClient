using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Meziantou.GitLab.Core;
using Xunit;

namespace Meziantou.GitLab.Tests.Models
{
    public partial class EntityTests
    {
        [Fact]
        public void ValidateJsonConverter()
        {
            var types = typeof(GitLabObject).Assembly.GetTypes()
                .Where(type => type.IsAssignableTo(typeof(GitLabObject)))
                .ToList();

            Assert.All(types, type => Assert.True(type.GetCustomAttribute<JsonConverterAttribute>(inherit: false) != null, $"Type '{type.FullName}' has not [JsonConverter] attribute"));
        }

        [Fact]
        public void Serialize_Deserialize()
        {
            var userJson = JsonSerializer.Serialize(new { id = 42, username = "test", dummy = "this property is not mapped" });

            var user = JsonSerializer.Deserialize<User>(userJson);
            var serialized = JsonSerializer.Serialize(user);

            Assert.Equal(userJson, serialized);
        }

        [Fact]
        public void User_ToJson()
        {
            var source = @"
{
  ""id"": 121,
  ""name"": ""user_20210101-143307_65c9eb13c6384d04b9537f2652fe09f3"",
  ""username"": ""user_20210101-143307_65c9eb13c6384d04b9537f2652fe09f3"",
  ""state"": ""active"",
  ""avatar_url"": ""https://www.gravatar.com/avatar/e11033656459b5fffea56657a19b7acc?s=80&d=identicon"",
  ""web_url"": ""http://localhost:48624/user_20210101-143307_65c9eb13c6384d04b9537f2652fe09f3"",
  ""created_at"": ""2021-01-01T19:33:07.323Z"",
  ""bio"": """",
  ""bio_html"": """",
  ""location"": null,
  ""public_email"": """",
  ""skype"": """",
  ""linkedin"": """",
  ""twitter"": """",
  ""website_url"": """",
  ""organization"": null,
  ""job_title"": """",
  ""work_information"": null,
  ""last_sign_in_at"": null,
  ""confirmed_at"": ""2021-01-01T19:33:07.298Z"",
  ""last_activity_on"": null,
  ""email"": ""user_20210101-143307_65c9eb13c6384d04b9537f2652fe09f3@dummy.com"",
  ""theme_id"": 1,
  ""color_scheme_id"": 1,
  ""projects_limit"": 100000,
  ""current_sign_in_at"": null,
  ""identities"": [],
  ""can_create_group"": true,
  ""can_create_project"": true,
  ""two_factor_enabled"": false,
  ""external"": false,
  ""private_profile"": false,
  ""shared_runners_minutes_limit"": null,
  ""extra_shared_runners_minutes_limit"": null,
  ""is_admin"": false,
  ""note"": null,
  ""using_license_seat"": false
}
";
            using var jsonDocument = JsonDocument.Parse(source);
            var element = jsonDocument.RootElement;
            var user = new User(element);

            var serializedJsonElement = JsonSerializer.Serialize(element);
            var serializedEntity = JsonSerializer.Serialize(user);
            Assert.Equal(serializedJsonElement, serializedEntity);
        }

    }
}
