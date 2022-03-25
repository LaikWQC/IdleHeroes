namespace IdleHeroes.Data
{
    public interface IAbilityDataBuilder
    {
        void AddDamage(string id, int potency);
        IEffectDataBuilder AddEffect(EffectDto effect);
    }
}
