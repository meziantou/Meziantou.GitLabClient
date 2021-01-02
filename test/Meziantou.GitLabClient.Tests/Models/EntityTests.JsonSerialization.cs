using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests.Models
{
    public partial class EntityTests
    {
        [TestMethod]
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
            Assert.AreEqual(serializedJsonElement, serializedEntity);
        }

    }
}
