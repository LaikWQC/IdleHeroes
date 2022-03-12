namespace IdleHeroes.Model
{
    public class AbilityData
    {
        private readonly string _id;
        private readonly int _cooldownMulti;

        public AbilityData(string id, int cooldownMulti)
        {
            _id = id;
            _cooldownMulti = cooldownMulti;
        }

        public void CreateAbility(HeroStatistic statistic)
        {
            statistic.Abilities[_id] = new AbilityModel.Builder(_cooldownMulti);
        }
    }
}
