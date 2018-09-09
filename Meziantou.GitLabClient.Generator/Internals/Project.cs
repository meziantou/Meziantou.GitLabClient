using System.Collections.Generic;

namespace Meziantou.GitLabClient.Generator
{
    internal class Project
    {
        public IList<Model> Models { get; } = new List<Model>();
        public IList<ParameterEntity> ParameterEntities { get; } = new List<ParameterEntity>();
        public IList<Method> Methods { get; } = new List<Method>();

        public T AddModel<T>(T model) where T : Model
        {
            Models.Add(model);
            return model;
        }

        public ParameterEntity AddParameterEntity(ParameterEntity parameterEntity)
        {
            ParameterEntities.Add(parameterEntity);
            return parameterEntity;
        }

        public Method AddMethod(Method method)
        {
            Methods.Add(method);
            return method;
        }
    }
}
