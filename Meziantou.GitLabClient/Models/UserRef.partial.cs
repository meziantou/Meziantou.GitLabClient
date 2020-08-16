using System.Globalization;

namespace Meziantou.GitLab
{
    public partial struct UserRef
    {
        public string ValueAsString
        {
            get
            {
                if (Value is string str)
                    return str;

                if (Value is long id)
                    return id.ToString(CultureInfo.InvariantCulture);

                return null;
            }
        }

        private UserRef(UserSafe user)
        {
            _value = user?.Id;
        }

        public static implicit operator UserRef(UserSafe user) => new UserRef(user);
    }
}
