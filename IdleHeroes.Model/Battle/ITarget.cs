namespace IdleHeroes.Model
{
    public interface ITarget
    {
        void TakeDamage(double damage);
        void ApplyEffect(EffectModel effect);
    }
}
