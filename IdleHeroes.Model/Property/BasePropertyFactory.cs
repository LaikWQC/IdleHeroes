using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class BasePropertyFactory : IPropertyFactory
    {
        public IProperty<T> Create<T>(T value = default) => new BaseProperty<T>(value);
    }
}
