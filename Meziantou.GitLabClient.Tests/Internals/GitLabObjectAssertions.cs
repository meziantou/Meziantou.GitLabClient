using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Meziantou.GitLab.Core;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabObjectAssertions
    {
        public static void DoesContainOnlyUtcDates(ISet<string> errorMessages, object o)
        {
            foreach (var obj in GetObjects(o))
            {
                var properties = TypeDescriptor.GetProperties(o);
                foreach (PropertyDescriptor property in properties)
                {
                    if (property.Attributes.OfType<SkipUtcDateValidationAttribute>().Any())
                        continue;

                    try
                    {
                        var propertyValue = property.GetValue(o);
                        if (propertyValue is DateTime dt)
                        {
                            if (dt.Kind != DateTimeKind.Utc)
                            {
                                errorMessages.Add(FormattableString.Invariant($"The value of '{o.GetType().Name}.{property.Name}' is not a UTC DateTime ({dt:o})"));
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static void DoesContainOnlyAbsoluteUri(ISet<string> errorMessages, object o)
        {
            foreach (var obj in GetObjects(o))
            {
                var properties = TypeDescriptor.GetProperties(o);
                foreach (PropertyDescriptor property in properties)
                {
                    if (property.Attributes.OfType<SkipAbsoluteUriValidationAttribute>().Any())
                        continue;

                    try
                    {
                        var propertyValue = property.GetValue(o);
                        if (propertyValue is Uri uri)
                        {
                            if (!uri.IsAbsoluteUri)
                            {
                                errorMessages.Add(FormattableString.Invariant($"The value of '{o.GetType().Name}.{property.Name}' is not an absolute URI ({uri})"));
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static void DoesNotContainUnmappedProperties(ISet<string> errorMessages, object o)
        {
            foreach (var obj in GetObjects(o))
            {
                var properties = TypeDescriptor.GetProperties(o);
                foreach (PropertyDescriptor property in properties)
                {
                    var attribute = property.Attributes.OfType<MappedPropertyAttribute>().FirstOrDefault();
                    if (attribute == null)
                        continue;

                    try
                    {
                        _ = property.GetValue(o);
                    }
                    catch
                    {
                        errorMessages.Add($"Property '{o.GetType().Name}.{attribute.Name}' is required but is not set");
                    }
                }
            }
        }

        private static IEnumerable<GitLabObject> GetObjects(object o)
        {
            switch (o)
            {
                case null:
                    return Enumerable.Empty<GitLabObject>();

                case GitLabObject value:
                    return new[] { value };

                case IEnumerable<GitLabObject> value:
                    return value;

                case object value:
                    var type = value.GetType();
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(PagedResponse<>))
                    {
                        return ((dynamic)value).Data;
                    }
                    break;
            }

            return Enumerable.Empty<GitLabObject>();
        }
    }
}
