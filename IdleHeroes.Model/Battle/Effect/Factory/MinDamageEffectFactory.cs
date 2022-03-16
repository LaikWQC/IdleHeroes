using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class MinDamageEffectFactory : EffectFactory
    {
        private MinDamageEffectFactory() { }

        public int Value { get; private set; }

        public override void ApplyEffect(ITarget target)
        {
            //TODO
        }

        public class Builder : IEffectFactoryBuilder
        {
            public Builder(int duration, EffectTargetTypes targetType, int value)
            {
                _product = new MinDamageEffectFactory();
                _product.Duration = duration;
                _product.TargetType = targetType;
                _product.Value = value;
            }

            public EffectFactory Product => _product;
            private MinDamageEffectFactory _product;
        }
    }
}
