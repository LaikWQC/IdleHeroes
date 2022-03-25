namespace IdleHeroes.Data
{
    public interface IEffectDataBuilder
    {
        void AddMinDamage(string id, int value);
        void AddDoT(string id, int potency);
        void AddIncomingDamage(string id, int value);
    }
}
