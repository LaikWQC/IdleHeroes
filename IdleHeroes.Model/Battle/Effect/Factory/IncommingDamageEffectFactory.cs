using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class IncommingDamageEffectFactory : EffectFactory
    {
        private IncommingDamageEffectFactory() { }

        public int Value { get; private set; }

        public override void ApplyEffect()
        {
            //TODO
        }

        public class Builder : IEffectFactoryBuilder
        {
            public Builder(int duration, EffectTargetTypes targetType, int value)
            {
                _product = new IncommingDamageEffectFactory();
                _product.Duration = duration;
                _product.TargetType = targetType;
                _product.Value = value;
            }

            public EffectFactory Product => _product;
            private IncommingDamageEffectFactory _product;
        }
    }
}
