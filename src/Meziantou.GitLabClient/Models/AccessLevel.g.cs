﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    public enum AccessLevel
    {
        NoAccess = 0,
        MinimalAccess = 5,
        Guest = 10,
        Reporter = 20,
        Developer = 30,
        Maintainer = 40,
        Owner = 50
    }
}

namespace Meziantou.GitLab.Internals
{
    internal partial struct UrlBuilder
    {
        public void AppendParameter(Meziantou.GitLab.AccessLevel value)
        {
            this.AppendParameter(((int)value));
        }
    }
}
