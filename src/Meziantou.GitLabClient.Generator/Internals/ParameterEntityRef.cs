using System;
using System.Collections.Generic;
using System.Linq;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ParameterEntityRef
    {
        private ParameterEntityRef(string name, ModelRef modelRef, ModelRef finalPropertyModelRef, params string[] properties)
        {
            Name = name;
            ModelRef = modelRef;
            FinalPropertyModelRef = finalPropertyModelRef;
            PropertyPath = properties;
        }

        public string Name { get; }
        public ModelRef ModelRef { get; }
        public IReadOnlyList<string> PropertyPath { get; }
        public ModelRef FinalPropertyModelRef { get; }

        public static ParameterEntityRef Create(string name, ModelRef model)
        {
            if (model.Model is Entity entity)
            {
                var keys = entity.Properties.Where(e => e.IsKey).ToList();
                if (keys.Count == 0)
                    throw new ArgumentException($"Entity '{entity.Name}' has no key property", nameof(model));

                if (keys.Count > 1)
                    throw new ArgumentException($"Entity '{entity.Name}' has multiple key properties", nameof(model));

                return new ParameterEntityRef(name, model, keys[0].Type, keys[0].Name);
            }

            return new ParameterEntityRef(name, model, model);
        }

        public static ParameterEntityRef Create(string name, ModelRef model, string propertyName)
        {
            if (model.Model is Entity entity)
            {
                var properties = entity.Properties.Where(e => e.Name == propertyName).ToList();
                if (properties.Count == 0)
                    throw new ArgumentException($"Entity '{entity.Name}' has no property named '{propertyName}'", nameof(model));

                if (properties.Count > 1)
                    throw new ArgumentException($"Entity '{entity.Name}' has multiple properties named '{propertyName}'", nameof(model));

                return new ParameterEntityRef(name, model, properties[0].Type, properties[0].Name);
            }

            return new ParameterEntityRef(name, model, model);
        }
    }
}
