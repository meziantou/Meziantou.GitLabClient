using System;
using System.Collections.Generic;
using System.Globalization;

namespace Meziantou.GitLab.Internals
{
    internal ref partial struct UrlBuilder
    {
        public void AppendRawParameter(string value)
        {
            Append(value);
        }

        public void AppendParameter(string value)
        {
            Append(Uri.EscapeDataString(value));
        }

        public void AppendParameter(int value)
        {
            AppendParameter(value.ToString(CultureInfo.InvariantCulture));
        }

        public void AppendParameter(long value)
        {
            AppendParameter(value.ToString(CultureInfo.InvariantCulture));
        }

        public void AppendParameter(bool value)
        {
            // No need to escape the value
            Append(value ? "true" : "false");
        }

        public void AppendParameter(DateTime value)
        {
            AppendParameter(value.ToString("o", CultureInfo.InvariantCulture));
        }

        public void AppendParameter(DateTimeOffset value)
        {
            AppendParameter(value.UtcDateTime.ToString("o", CultureInfo.InvariantCulture));
        }

        public void AppendParameter(PathWithNamespace value)
        {
            AppendParameter(value.FullPath);
        }

        public void AppendParameter(IEnumerable<string> values)
        {
            var first = true;
            foreach (var value in values)
            {
                if (!first)
                {
                    Append(',');
                }

                AppendParameter(value);
                first = false;
            }
        }

        public void AppendParameter(IEnumerable<long> values)
        {
            var first = true;
            foreach (var value in values)
            {
                if (!first)
                {
                    Append(',');
                }

                AppendParameter(value.ToString(CultureInfo.InvariantCulture));
                first = false;
            }
        }
    }
}
