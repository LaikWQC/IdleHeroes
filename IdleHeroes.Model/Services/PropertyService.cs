using System.Collections.Generic;

namespace IdleHeroes.Model.Services
{
    public class PropertyService : Singletone<PropertyService>
    {
        private IPropertyFactory _factory;
        
        public PropertyService()
        {
            Initialize(null);
        }

        public void Initialize(IPropertyFactory factory)
        {
            _factory = factory ?? new BasePropertyFactory();
        }

        public IProperty<T> CreateProperty<T>(T value = default) => _factory.Create(value);
    }
}
