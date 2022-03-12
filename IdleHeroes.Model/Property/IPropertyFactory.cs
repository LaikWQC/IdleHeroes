using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public interface IPropertyFactory
    {
        IProperty<T> Create<T>(T value = default);
    }
}
