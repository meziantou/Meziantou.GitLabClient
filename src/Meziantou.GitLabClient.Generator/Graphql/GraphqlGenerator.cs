using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Meziantou.Framework;
using Meziantou.Framework.CodeDom;

namespace Meziantou.GitLabClient.Generator.Graphql
{
    public class GraphqlGenerator
    {
        private readonly GraphqlModel _model;

        public GraphqlGenerator(GraphqlModel model)
        {
            _model = model;
        }

        [SuppressMessage("Usage", "CA1801:Review unused parameters", Justification = "Not yet implemented")]
        public void Generate(FullPath directory)
        {
            var file = new CompilationUnit();
            GenerateQueries(file, ResolveType(_model.QueryType));

            //file.WriteUnit(directory / "GitLabClient.Graphql.g.cs");
        }

        public static async Task GenerateAsync(FullPath directory, bool noCache)
        {
            var model = await GraphqlModel.GetAsync(noCache);
            var generator = new GraphqlGenerator(model);
            generator.Generate(directory);
        }

        private GraphqlType ResolveType(GraphqlTypeRef type)
        {
            return _model.GetTypeByName(type.Name);
        }

        private static void GenerateQueries(CompilationUnit unit, GraphqlType type)
        {
            // generate response types + Connection types + input types
            // e.g. User / UserConnection / UserWhere / UserSelect
            foreach (var field in type.Fields)
            {
                var ns = unit.AddNamespace("Meziantou.GitLabClient.Graphql");

                ns.AddType(new ClassDeclaration(field.Name + "QueryBuilder"));

                if (field.Args != null)
                {
                    var argsType = ns.AddType(new ClassDeclaration(field.Name + "Args"));

                    foreach (var arg in field.Args)
                    {
                        argsType.AddMember(new PropertyDeclaration(arg.Name, typeof(object)));
                    }
                }

            }
        }
    }
}
