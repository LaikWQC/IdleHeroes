using IdleHeroes.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdleHeroes.Model
{
    public class LimitedValue
    {
        public LimitedValue(double maxValue = 0D) : this(maxValue, maxValue) { }
        public LimitedValue(double maxValue, double currentValue)
        {
            Max = PropertyService.Instance.CreateProperty(maxValue);
            Current = PropertyService.Instance.CreateProperty(currentValue);

            Max.ValueChanged += OnMaxChaged;
            Current.ValueChanged += OnCurrentChaged;
        }

        public IProperty<double> Max { get; }
        public IProperty<double> Current { get; }

        private void OnMaxChaged()
        {
            if (Max.Value < 0) Max.Value = 0;
            if (Current.Value > Max.Value) Current.Value = Max.Value;
        }
        private void OnCurrentChaged()
        {
            if (Current.Value < 0) Current.Value = 0;
            if (Current.Value > Max.Value) Current.Value = Max.Value;
        }

        public bool IsMaxed => Current.Value == Max.Value;
        public bool IsMined => Current.Value == 0;
    }
}
