using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public abstract class EffectData
    {
        protected readonly EffectTargetTypes _targetType;
        protected readonly int _duration;

        public EffectData(EffectTargetTypes targetType, int duration)
        {
            _targetType = targetType;
            _duration = duration;
        }

        public abstract EffectFactory EnsureCreateEffectFactory(HeroStatistic statistic);
    }
}
