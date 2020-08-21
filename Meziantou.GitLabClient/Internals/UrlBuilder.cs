﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Meziantou.GitLab
{
    // TODO improve performance
    // TODO create overloads of WithValue for specific types
    // TODO generate values for enum
    internal sealed class UrlBuilder
    {
        private static readonly ConcurrentDictionary<Type, EnumDescriptor> s_enumDescriptors = new ConcurrentDictionary<Type, EnumDescriptor>();

        private UrlBuilder(string template)
        {
            Template = template;
        }

        public static UrlBuilder Get(string template)
        {
            return new UrlBuilder(template);
        }

        private IDictionary<string, string> Parameters { get; } = new Dictionary<string, string>(StringComparer.Ordinal);

        public string Template { get; }

        public UrlBuilder WithValue(string key, object? value)
        {
            switch (value)
            {
                case null:
                    Parameters.Remove(key);
                    break;

                case string v:
                    Parameters[key] = v;
                    break;

                case bool v:
                    Parameters[key] = v ? "true" : "false";
                    break;

                case int v:
                    Parameters[key] = string.Format(CultureInfo.InvariantCulture, "{0}", v);
                    break;

                case long v:
                    Parameters[key] = string.Format(CultureInfo.InvariantCulture, "{0}", v);
                    break;

                case DateTime v:
                    Parameters[key] = v.ToString("o", CultureInfo.InvariantCulture);
                    break;

                case Enum v:
                    Parameters[key] = FormatEnum(v);
                    break;

                case PathWithNamespace v:
                    Parameters[key] = v.FullPath;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }

            return this;

            string FormatEnum(Enum enumValue)
            {
                var descriptor = s_enumDescriptors.GetOrAdd(enumValue.GetType(), type => EnumDescriptor.Build(type));
                if (descriptor.IsFlags)
                {
                    return string.Join(",", descriptor.Values.Where(ev => enumValue.HasFlag(ev.Key)).Select(ev => ev.Value));
                }

                return descriptor.Values[enumValue];
            }
        }

        public string Build()
        {
            var url = Template;
            foreach (var parameter in Parameters)
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

        // TODO remove and use generated WriteValue
        private sealed class EnumDescriptor
        {
            public bool IsFlags { get; }
            public Dictionary<Enum, string> Values { get; }

            public EnumDescriptor(bool isFlags, Dictionary<Enum, string> values)
            {
                IsFlags = isFlags;
                Values = values ?? throw new ArgumentNullException(nameof(values));
            }

            public static EnumDescriptor Build(Type type)
            {
#if DEBUG
                if (!type.IsEnum)
                    throw new ArgumentException("type must be an enumeration", nameof(type));
#endif

                var isFlags = type.GetCustomAttribute<FlagsAttribute>() != null;
                var names = Enum.GetNames(type).ToDictionary(
                    name => (Enum)Enum.Parse(type, name),
                    name => type.GetField(name).GetCustomAttribute<EnumMemberAttribute>().Value); // In our case the attribute must be present

                return new EnumDescriptor(isFlags, names);
            }
        }
    }
}
