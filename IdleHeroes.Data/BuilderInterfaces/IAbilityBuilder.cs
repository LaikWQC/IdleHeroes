namespace IdleHeroes.Data
{
    public interface IAbilityBuilder
    {
        void AddDamage(int potency);
        IEffectBuilder AddEffect(EffectDto effect);
    }
}
