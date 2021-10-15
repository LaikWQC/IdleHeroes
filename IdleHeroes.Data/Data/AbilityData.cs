namespace IdleHeroes.Data
{
    public class AbilityData
    {
        public AbilityData(string id, double prepareTime)
        {
            Id = id;
            PrepareTime = prepareTime;
        }

        public string Id { get; }
        public double PrepareTime { get; }
    }
}
