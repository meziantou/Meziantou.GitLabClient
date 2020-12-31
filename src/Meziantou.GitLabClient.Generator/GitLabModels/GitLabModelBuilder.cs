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
            (from prop in typeof(Models).GetProperties()
             where prop.PropertyType == typeof(ModelRef)
             let value = (ModelRef)prop.GetValue(null)
             where value?.Model is Enumeration
             select value.Model).ForEach(model => project.AddModel(model));
            // TODO validate enum name matches property name

            // Entities
            (from prop in typeof(Models).GetProperties()
             where prop.PropertyType.IsAssignableTo(typeof(EntityBuilder))
             let value = (EntityBuilder)prop.GetValue(null)
             select value).ForEach(model => { model.Build(); project.AddModel(model.Value); });
            // TODO validate entity matches property name

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
