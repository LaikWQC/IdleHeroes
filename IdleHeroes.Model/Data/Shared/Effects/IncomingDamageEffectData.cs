using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class IncomingDamageEffectData : EffectData
    {
        private readonly int _value;

        public IncomingDamageEffectData(EffectTargetTypes targetType, int duration, int value) : base(targetType, duration)
        {
            _value = value;
        }

        public override EffectFactory EnsureCreateEffectFactory(HeroStatistic statistic)
        {
            if (!statistic.Effects.TryGetValue(this, out var factory))
                statistic.Effects[this] = factory = new IncommingDamageEffectFactory.Builder(_duration, _targetType, _value);
            return factory.Product;
        }
    }
}
