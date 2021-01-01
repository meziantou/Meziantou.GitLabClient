using System;
using System.Globalization;

namespace Meziantou.GitLab
{
    public partial struct UserIdOrUserNameRef
    {
        public string ValueAsString
        {
            get
            {
                if (Value is string str)
                    return str;

                if (Value is long id)
                    return id.ToString(CultureInfo.InvariantCulture);

                throw new InvalidOperationException($"Value of type '{Value.GetType()}' is not supported");
            }
        }
    }
}
