namespace IdleHeroes.Data
{
    public interface IAbilityDataBuilder
    {
        void AddDamage(int potency);
        IEffectDataBuilder AddEffect(EffectDto effect);
    }
}
