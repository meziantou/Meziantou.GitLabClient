using System;
using System.Linq;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class GitLabModelBuilder
    {
        public static Project Create()
        {
            var project = new Project();

            // Create Enumerations
            foreach (var (prop, enumeration) in from prop in typeof(Models).GetProperties()
                                                where prop.PropertyType == typeof(ModelRef)
                                                let value = (ModelRef)prop.GetValue(null)
                                                where value?.Model is Enumeration
                                                select (prop, value.Model))
            {
                if (prop.Name != enumeration.Name)
                    throw new InvalidOperationException($"The enumeration '{enumeration.Name}' does not match the property name '{prop.Name}'");

                project.AddModel(enumeration);
            }

            // Entities
            foreach (var (prop, entity) in from prop in typeof(Models).GetProperties()
                                           where prop.PropertyType.IsAssignableTo(typeof(EntityBuilder))
                                           let value = (EntityBuilder)prop.GetValue(null)
                                           select (prop, value))
            {
                entity.Build();
                if (prop.Name != entity.Value.Name)
                    throw new InvalidOperationException($"The entity '{entity.Value.Name}' does not match the property name '{prop.Name}'");

                project.AddModel(entity.Value);
            }

            // Create Entity refs
            foreach (var (prop, parameterEntityRef) in from prop in typeof(Models).GetProperties()
                                                       where prop.PropertyType.IsAssignableTo(typeof(ParameterEntityBuilder))
                                                       let value = (ParameterEntityBuilder)prop.GetValue(null)
                                                       select (prop, value))
            {
                parameterEntityRef.Build();
                if (prop.Name != parameterEntityRef.Value.Name)
                    throw new InvalidOperationException($"The parameter entity '{parameterEntityRef.Value.Name}' does not match the property name '{prop.Name}'");

                project.AddParameterEntity(parameterEntityRef.Value);
            }

            // Create Methods
            foreach (var type in from type in typeof(GitLabClientBuilder).Assembly.GetTypes()
                                 where !type.IsAbstract && type.IsAssignableTo(typeof(GitLabClientBuilder))
                                 select type)
            {
                var instance = (GitLabClientBuilder)Activator.CreateInstance(type);
                instance.Create(project);
            }

            Validate(project);
            return project;
        }

        private static void Validate(Project project)
        {
            // Validate parameter entities are used
            ValidateParameterEntitiesAreUsed(project);

            static void ValidateParameterEntitiesAreUsed(Project project)
            {
                var all = project.ParameterEntities.ToList();
                foreach (var method in project.MethodGroups.SelectMany(g => g.Methods))
                {
                    foreach (var parameter in method.Parameters)
                    {
                        if (parameter.Type.ParameterEntity != null)
                        {
                            all.Remove(parameter.Type.ParameterEntity);
                        }
                    }
                }

                if (all.Count > 0)
                    throw new InvalidOperationException($"Parameter entity '{all[0].Name}' is not used");
            }
        }
    }
}
