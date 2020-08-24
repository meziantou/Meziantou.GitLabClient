using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Meziantou.GitLab
{
    internal sealed partial class UrlBuilder
    {
        private readonly List<KeyValuePair<string, string>> _parameters = new List<KeyValuePair<string, string>>();

        private UrlBuilder(string template)
        {
            Template = template;
        }

        public static UrlBuilder Get(string template)
        {
            return new UrlBuilder(template);
        }

        public string Template { get; }

        public void SetValue(string key, string? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetStringValue(key, value);
            }
        }

        public void SetValue(string key, bool? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, bool value)
        {
            SetStringValue(key, value ? "true" : "false");
        }

        public void SetValue(string key, int? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, int value)
        {
            SetStringValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetValue(string key, long? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, long value)
        {
            SetStringValue(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetValue(string key, DateTime? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, DateTime value)
        {
            SetStringValue(key, value.ToString("o", CultureInfo.InvariantCulture));
        }

        public void SetValue(string key, DateTimeOffset? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, DateTimeOffset value)
        {
            SetStringValue(key, value.UtcDateTime.ToString("o", CultureInfo.InvariantCulture));
        }

        public void SetValue(string key, PathWithNamespace? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, PathWithNamespace value)
        {
            SetStringValue(key, value.FullPath);
        }

        public void SetValue(string key, IEnumerable<string>? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                SetStringValue(key, string.Join(',', value));
            }
        }

        public void SetValue(string key, IEnumerable<long>? value)
        {
            if (value is null)
            {
                RemoveValues(key);
            }
            else
            {
                // TODO optimize with a string builder?
                SetStringValue(key, string.Join(',', value.Select(v => v.ToString(CultureInfo.InvariantCulture))));
            }
        }

        private void RemoveValues(string key)
        {
            _parameters.RemoveAll(item => item.Key == key);
        }

        private void SetStringValue(string key, string value)
        {
            _parameters.Add(new KeyValuePair<string, string>(key, value));
        }

        public string Build()
        {
            var url = Template;
            foreach (var parameter in _parameters)
            {
                var parameterValue = parameter.Value;
                var newUrl = Regex.Replace(
                    url,
                    "(?<=^|/)(:" + Regex.Escape(parameter.Key) + ")(?=\\?|#|/|$)",
                    Uri.EscapeDataString(parameterValue),
                    RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture,
                    TimeSpan.FromSeconds(1));

                if (newUrl != url)
                {
                    url = newUrl;
                }
                else
                {
                    // Append to query string
                    if (url.Contains('?', StringComparison.Ordinal))
                    {
                        url += "&" + Uri.EscapeDataString(parameter.Key) + "=" + Uri.EscapeDataString(parameterValue);
                    }
                    else
                    {
                        url += "?" + Uri.EscapeDataString(parameter.Key) + "=" + Uri.EscapeDataString(parameterValue);
                    }
                }
            }

            return url;
        }
    }
}
