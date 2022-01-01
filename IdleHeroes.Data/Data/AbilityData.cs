namespace IdleHeroes.Data
{
    public class AbilityData
    {
        public AbilityData(string id, double cooldownMulti)
        {
            Id = id;
            CooldownMulti = cooldownMulti;
        }

        public string Id { get; }
        public double CooldownMulti { get; }
    }
}
