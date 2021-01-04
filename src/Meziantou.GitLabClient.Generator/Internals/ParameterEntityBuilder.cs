using System;

namespace Meziantou.GitLabClient.Generator
{
    internal sealed class ParameterEntityBuilder
    {
        private readonly Action<ParameterEntity> _configure;

        public ParameterEntityBuilder(string name, Action<ParameterEntity> configure)
        {
            Value = new ParameterEntity(name);
            _configure = configure;
        }

        public ParameterEntity Value { get; }

        public void Build()
        {
            _configure(Value);
        }

        public static implicit operator ModelRef(ParameterEntityBuilder builder) => builder.Value;
        public static implicit operator ParameterEntity(ParameterEntityBuilder builder) => builder.Value;

        public ModelRef AsModelRef() => Value;
    }
}
