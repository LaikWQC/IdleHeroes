using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class DoTEffectFactory : EffectFactory
    {
        private DoTEffectFactory() { }

        public int Potency { get; private set; }

        public override void ApplyEffect(ITarget target)
        {
            //TODO
        }

        public class Builder : IEffectFactoryBuilder
        {
            public Builder(int duration, EffectTargetTypes targetType, int potency)
            {
                _product = new DoTEffectFactory();
                _product.Duration = duration;
                _product.TargetType = targetType;
                _product.Potency = potency;
            }

            public EffectFactory Product => _product;
            private DoTEffectFactory _product;
        }
    }
}
