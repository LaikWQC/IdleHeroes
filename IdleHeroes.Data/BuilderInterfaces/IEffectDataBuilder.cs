namespace IdleHeroes.Data
{
    public interface IEffectDataBuilder
    {
        void AddMinDamage(int value);
        void AddDoT(int potency);
        void AddIncomingDamage(int value);
    }
}
