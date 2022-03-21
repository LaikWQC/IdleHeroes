namespace IdleHeroes.Data
{
    public interface IEffectBuilder
    {
        void AddMinDamage(int value);
        void AddDoT(int potency);
        void AddIncomingDamage(int value);
    }
}
