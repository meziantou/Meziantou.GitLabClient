using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabObjectAssertions
    {
        public static void DoesContainOnlyUtcDates(object o)
        {
            foreach (var obj in GetObjects(o))
            {
                var properties = TypeDescriptor.GetProperties(o);
                foreach (PropertyDescriptor property in properties)
                {
                    if (property.Attributes.OfType<SkipUtcDateValidationAttribute>().Any())
                        continue;

                    var propertyValue = property.GetValue(o);
                    if (propertyValue is DateTime dt)
                    {
                        Assert.AreEqual(DateTimeKind.Utc, dt.Kind, $"The value of '{o.GetType().FullName}.{property.Name}' is not a UTC DateTime ({dt.ToString("o")}).");
                    }
                }
            }
        }

        public static void DoesContainGitLabClient(object o, bool validateChildProperties = true)
        {
            foreach (var obj in GetObjects(o))
            {
                Assert.IsNotNull(((IGitLabObject)obj).GitLabClient);

                if (validateChildProperties)
                {
                    var properties = TypeDescriptor.GetProperties(o);
                    foreach (PropertyDescriptor property in properties)
                    {
                        var propertyValue = property.GetValue(o);
                        DoesContainGitLabClient(propertyValue, validateChildProperties);
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
