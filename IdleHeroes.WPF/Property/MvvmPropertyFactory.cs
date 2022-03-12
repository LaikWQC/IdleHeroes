using IdleHeroes.Model;

namespace IdleHeroes.WPF
{
    public class MvvmPropertyFactory : IPropertyFactory
    {
        public IProperty<T> Create<T>(T value = default) => new MvvmProperty<T>(value);
    }
}
