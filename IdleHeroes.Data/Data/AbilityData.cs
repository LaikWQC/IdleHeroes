namespace IdleHeroes.Data
{
    public class AbilityData
    {
        public AbilityData(string id, int cooldownMulti)
        {
            Id = id;
            CooldownMulti = cooldownMulti;
        }

        public string Id { get; }
        public int CooldownMulti { get; }
    }
}
