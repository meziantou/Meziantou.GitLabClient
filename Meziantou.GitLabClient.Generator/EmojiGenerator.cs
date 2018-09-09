using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Meziantou.Framework.CodeDom;
using Newtonsoft.Json;

namespace Meziantou.GitLabClient.Generator
{
    internal class EmojiGenerator
    {
        public async Task Generate()
        {
            var unit = new CompilationUnit();
            var ns = unit.AddNamespace("Meziantou.GitLab");

            var emojiClass = ns.AddType(new ClassDeclaration("Emoji") { Modifiers = Modifiers.Public | Modifiers.Partial | Modifiers.Static });

            using (var httpClient = new HttpClient())
            {
                using (var result = await httpClient.GetAsync("https://raw.githubusercontent.com/jonathanwiesel/gemojione/master/config/index.json"))
                {
                    var str = await result.Content.ReadAsStringAsync();
                    var emojis = JsonConvert.DeserializeObject<Dictionary<string, Emoji>>(str);
                    foreach (var kvp in emojis.OrderBy(entry => entry.Key))
                    {
                        var constant = new FieldDeclaration("Emoji" + GetName(kvp.Key), typeof(string), Modifiers.Public | Modifiers.Const)
                        {
                            InitExpression = new LiteralExpression(kvp.Key)
                        };

                        var field = emojiClass.AddMember(constant);
                        field.XmlComments.AddSummary($"Emoji {kvp.Value.Name} {kvp.Value.Moji}");
                    }
                }
            }

            using (var tw = new StreamWriter("../../../../Meziantou.GitLabClient/Emoji.cs"))
            {
                new CSharpCodeGenerator().Write(tw, unit);
            }

            string GetName(string value)
            {
                return value.Split(new[] { '_', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
                    .Aggregate(string.Empty, (s1, s2) => s1 + s2);
            }
        }

        private class Emoji
        {
            public string Name { get; set; }
            public string Moji { get; set; }
            public string Shortname { get; set; }
        }
    }
}
