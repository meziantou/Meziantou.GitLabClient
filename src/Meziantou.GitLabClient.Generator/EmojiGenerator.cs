#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator
{
    internal static class EmojiGenerator
    {
        public static async Task GenerateAsync(FullPath rootDirectory)
        {
            var unit = new CompilationUnit();
            var ns = unit.AddNamespace("Meziantou.GitLab");

            var emojiClass = ns.AddType(new ClassDeclaration("Emoji") { Modifiers = Modifiers.Public | Modifiers.Partial | Modifiers.Static });

            using var httpClient = new HttpClient();

            using var result = await httpClient.GetAsync("https://raw.githubusercontent.com/jonathanwiesel/gemojione/master/config/index.json").ConfigureAwait(false);
            var str = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var emojis = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Emoji>>(str);
            if (emojis == null)
                throw new InvalidOperationException("Emojis is null");

            var named = new HashSet<string>(StringComparer.Ordinal);
            foreach (var kvp in emojis.OrderBy(entry => entry.Value.Moji).ThenBy(entry => entry.Key))
            {
                Debug.Assert(!string.IsNullOrEmpty(kvp.Value.Name));

                var name = kvp.Key.StartsWith("flag_", StringComparison.Ordinal) ? kvp.Key : kvp.Value.Name;
                var constant = new FieldDeclaration("Emoji" + GetName(name), typeof(string), Modifiers.Public | Modifiers.Const)
                {
                    InitExpression = new LiteralExpression(kvp.Key),
                };

                var field = emojiClass.AddMember(constant);
                field.XmlComments.AddSummary($"Emoji {kvp.Value.Name} '{kvp.Value.Moji}' (U+{kvp.Value.Unicode}) in category {kvp.Value.Category}");
            }

            using (var tw = new StreamWriter(rootDirectory / "Emoji.cs", append: false, Encoding.UTF8))
            {
                new CSharpCodeGenerator().Write(tw, unit);
            }

            string GetName(string value)
            {
                for (var i = 0; i < 1000; i++)
                {
                    var name = value
                        .Replace("’", "", StringComparison.Ordinal)
                        .Replace("'", "", StringComparison.Ordinal)
                        .Split(new[] { '_', '-', ' ', ':', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => char.ToUpperInvariant(s[0]) + s[1..])
                        .Aggregate(string.Empty, (s1, s2) => s1 + s2)
                        + (i == 0 ? "" : i.ToString(CultureInfo.InvariantCulture));

                    if (named.Add(name))
                        return name;
                }

                throw new InvalidOperationException($"Cannot generate name for '{value}'");
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812", Justification = "false positive")]
        private sealed class Emoji
        {
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonPropertyName("moji")]
            public string? Moji { get; set; }
            [JsonPropertyName("shortname")]
            public string? ShortName { get; set; }
            [JsonPropertyName("category")]
            public string? Category { get; set; }
            [JsonPropertyName("unicode")]
            public string? Unicode { get; set; }
        }
    }
}
