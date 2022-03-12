using System;
using System.Collections.Generic;
using System.Text;

namespace IdleHeroes.Model
{
    public interface IProperty<T>
    {
        public T Value { get; set; }
        event Action ValueChanged;
    }
}
