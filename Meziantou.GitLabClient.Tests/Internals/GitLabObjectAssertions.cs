using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.GitLab.Tests
{
    public static class GitLabObjectAssertions
    {
        public static void DoesNotContainUnmappedProperties(object o, bool validateChildProperties = true)
        {
            if (o == null)
                return;

            if (o is GitLabObject obj)
            {
                if (obj.AdditionalData.Count > 0)
                {
                    Assert.Fail($"Type '{obj.GetType().FullName}' has unmapped properties: {string.Join(", ", obj.AdditionalData.Keys)}");
                }

                if (validateChildProperties)
                {
                    var properties = TypeDescriptor.GetProperties(obj);
                    foreach (PropertyDescriptor prop in properties)
                    {
                        DoesNotContainUnmappedProperties(prop.GetValue(obj), validateChildProperties);
                    }
                }
            }

            if (o is IEnumerable<GitLabObject> enumerable)
            {
                foreach (var item in enumerable)
                {
                    DoesNotContainUnmappedProperties(item, validateChildProperties);
                }
            }
        }

        public static void DoesContainOnlyUtcDates(object o, bool validateChildProperties = true)
        {
            if (o == null)
                return;

            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor property in properties)
            {
                if (property.Attributes.OfType<SkipUtcDateValidationAttribute>().Any())
                    continue;

                var propertyValue = property.GetValue(o);
                if (propertyValue is DateTime dt)
                {
                    Assert.AreEqual(DateTimeKind.Utc, dt.Kind, $"The value of '{o.GetType().FullName}.{property.Name}' is not a UTC DateTime.");
                }
            }

            if (o is IEnumerable<GitLabObject> enumerable)
            {
                foreach (var item in enumerable)
                {
                    DoesContainOnlyUtcDates(item, validateChildProperties);
                }
            }
        }

        public static void DoesContainGitLabClient(object o, bool validateChildProperties = true)
        {
            if (o == null)
                return;

            if (o is GitLabObject glo)
            {
                Assert.IsNotNull(glo.GitLabClient);

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

            if (o is IEnumerable<GitLabObject> enumerable)
            {
                foreach (var item in enumerable)
                {
                    DoesContainGitLabClient(item, validateChildProperties);
                }
            }
        }
    }
}
