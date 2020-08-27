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

            // Create Enumerations
            typeof(Enumerations).GetMethods()
                .Where(m => m.IsPublic && m.IsStatic && m.GetParameters().Length == 1)
                .ForEach(m => m.Invoke(null, new object[] { project }));

            // Entities
            Entities.PreCreate();
            typeof(Entities).GetMethods()
                .Where(m => m.IsPublic && m.IsStatic && m.GetParameters().Length == 0)
                .ForEach(m => m.Invoke(null, Array.Empty<object>()));
            Entities.PostCreate(project);

            // Create Entity refs
            typeof(EntityRefs).GetMethods()
               .Where(m => m.IsPublic && m.IsStatic && m.GetParameters().Length == 1)
               .ForEach(m => m.Invoke(null, new object[] { project }));

            // Create Methods
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
