#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Meziantou.GitLab
{
    // TODO improve performance
    // TODO create overloads of WithValue for specific types
    // TODO generate values for enum
    internal sealed partial class UrlBuilder
    {
        [SuppressMessage("Usage", "MA0002:IEqualityComparer<string> is missing", Justification = "The default comparer is the one needed (Ordinal) and not providing it may be faster")]
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

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
                SetNullValue(key);
            }
            else
            {
                _parameters[key] = value;
            }
        }

        public void SetValue(string key, bool? value)
        {
            if (value is null)
            {
                SetNullValue(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, bool value)
        {
            _parameters[key] = value ? "true" : "false";
        }

        public void SetValue(string key, int? value)
        {
            if (value is null)
            {
                SetNullValue(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, int value)
        {
            _parameters[key] = value.ToString(CultureInfo.InvariantCulture);
        }

        public void SetValue(string key, long? value)
        {
            if (value is null)
            {
                SetNullValue(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, long value)
        {
            _parameters[key] = value.ToString(CultureInfo.InvariantCulture);
        }

        public void SetValue(string key, DateTime? value)
        {
            if (value is null)
            {
                SetNullValue(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, DateTime value)
        {
            _parameters[key] = value.ToString("o", CultureInfo.InvariantCulture);
        }

        public void SetValue(string key, PathWithNamespace? value)
        {
            if (value is null)
            {
                SetNullValue(key);
            }
            else
            {
                SetValue(key, value.GetValueOrDefault());
            }
        }

        public void SetValue(string key, PathWithNamespace value)
        {
            _parameters[key] = value.FullPath;
        }

        private void SetNullValue(string key)
        {
            _parameters.Remove(key);
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
