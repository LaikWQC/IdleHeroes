using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class DoTEffectData : EffectData
    {
        private readonly int _potency;

        public DoTEffectData(EffectTargetTypes targetType, int duration, int potency) : base(targetType, duration)
        {
            _potency = potency;
        }

        public override EffectFactory EnsureCreateEffectFactory(HeroStatistic statistic)
        {
            if (!statistic.Effects.TryGetValue(this, out var factory))
                statistic.Effects[this] = factory = new DoTEffectFactory.Builder(_duration, _targetType, _potency);
            return factory.Product;
        }
    }
}
