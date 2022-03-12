using System;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class BaseProperty<T> : IProperty<T>
    {
        public BaseProperty(T value = default)
        {
            _value = value;
        }

        public T Value 
        {
            get => _value;
            set
            {
                if (_value?.Equals(value) == true) return;
                _value = value;
                ValueChanged?.Invoke();
            }
        }
        private T _value;

        public event Action ValueChanged;
    }
}
