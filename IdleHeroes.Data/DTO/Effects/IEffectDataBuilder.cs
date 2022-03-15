namespace IdleHeroes.Data
{
    public interface IEffectDataBuilder
    {
        void AddEffect(MinDamageEffectDto effect);
        void AddEffect(DoTEffectDto effect);
        void AddEffect(IncomingDamageEffectDto effect);
    }
}
