namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Entities
    {
        internal static void PreCreate()
        {
            // Ensure values are created
            foreach (var property in typeof(Entities).GetProperties())
            {
                var value = new EntityBuilder(property.Name);
                property.SetMethod.Invoke(obj: null, parameters: new object[] { value });
            }
        }

        internal static void PostCreate(Project project)
        {
            // Ensure values are created
            foreach (var property in typeof(Entities).GetProperties())
            {
                var entityBuilder = (EntityBuilder)property.GetGetMethod().Invoke(obj: null, parameters: null);
                entityBuilder.Build();
                project.AddModel<Entity>(entityBuilder.Value);
            }
        }
    }
}
