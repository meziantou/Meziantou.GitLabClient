using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Meziantou.GitLab
{
    internal class UrlBuilder
    {
        private UrlBuilder(string template)
        {
            Template = template;
        }

        public static UrlBuilder Get(string template)
        {
            return new UrlBuilder(template);
        }

        public string Template { get; }

        public IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        public UrlBuilder WithValue(string key, object value)
        {
            Parameters[key] = value;
            return this;
        }

        public string Build()
        {
            var url = Template;
            foreach (var parameter in Parameters)
            {
                var parameterValue = FormatValue(parameter.Value);
                var newUrl = Regex.Replace(
                    url,
                    "(?<=^|/)(:" + Regex.Escape(parameter.Key) + ")(?=\\?|#|/|$)",
                    Uri.EscapeDataString(parameterValue),
                    RegexOptions.CultureInvariant);

                if (newUrl != url)
                {
                    url = newUrl;
                }
                else
                {
                    // Append to query string
                    var index = url.IndexOf('?');
                    if (index >= 0)
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

        private string FormatValue(object value)
        {
            if (value == null)
                return "";

            if (value is string str)
                return str;

            var type = value.GetType();
            if (type.IsEnum)
            {
#if DEBUG
                if (type.GetEnumUnderlyingType() != typeof(int))
                    throw new NotSupportedException("Enumeration must be of type int");
#endif

                if (type.GetCustomAttribute<FlagsAttribute>() != null)
                {
                    var intValue = (int)value;
                    if (intValue == 0)
                        return "";

                    var enumValues = Enum.GetValues(type);
                    var values = enumValues
                        .Cast<int>()
                        .Where(enumValue => enumValue != 0 && (intValue & enumValue) == enumValue)
                        .Select(_ => EnumValueToString(type, _));
                    return string.Join(",", values);
                }
                else
                {
                    return EnumValueToString(type, value);
                }
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        private string EnumValueToString(Type type, object value)
        {
            return SnakeCase(Enum.GetName(type, value));
        }

        private static string SnakeCase(string value)
        {
            return string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
