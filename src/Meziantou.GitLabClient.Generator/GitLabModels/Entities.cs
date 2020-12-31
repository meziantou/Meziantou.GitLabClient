using System.Linq;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Models
    {
        internal static void PreCreate()
        {
            // Ensure values are created
            foreach (var property in typeof(Models).GetProperties().Where(p => p.CanWrite))
            {
                var value = new EntityBuilder(property.Name);
                property.SetMethod.Invoke(obj: null, parameters: new object[] { value });
            }
        }
    }
}
