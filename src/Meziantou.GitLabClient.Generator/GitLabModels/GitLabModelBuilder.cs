using System;
using System.Linq;
using Meziantou.Framework;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class GitLabModelBuilder
    {
        public static Project Create()
        {
            var project = new Project();
            Enumerations.Create(project);
            Entities.Create(project);
            EntityRefs.Create(project);

            typeof(GitLabModelBuilder).Assembly.GetTypes()
                .Where(t => typeof(IGitLabClientDescriptor).IsAssignableFrom(t) && t.IsClass)
                .ForEach(t =>
                {
                    var instance = (IGitLabClientDescriptor)Activator.CreateInstance(t);
                    instance.Create(project);
                });

            return project;
        }
    }
}
