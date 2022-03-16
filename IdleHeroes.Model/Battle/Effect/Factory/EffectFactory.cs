using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public interface IEffectFactoryBuilder
    {
        EffectFactory Product { get; }
    }
    public abstract class EffectFactory
    {
        public int Duration { get; protected set; }
        public EffectTargetTypes TargetType { get; protected set; }
        public abstract void ApplyEffect(ITarget target);
    }
}
