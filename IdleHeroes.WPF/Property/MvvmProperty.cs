using IdleHeroes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IdleHeroes.WPF
{
    public class MvvmProperty<T> : BaseProperty<T>, INotifyPropertyChanged
    {
        public MvvmProperty(T value = default) : base(value)
        {
            ValueChanged += () => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
