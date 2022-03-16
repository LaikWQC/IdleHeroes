namespace IdleHeroes.Model
{
    public class AbilityData
    {
        private readonly string _name;
        private readonly string _id;
        private readonly int _cooldownMulti;

        public AbilityData(string name, string id, int cooldownMulti)
        {
            _name = name;
            _id = id;
            _cooldownMulti = cooldownMulti;
        }

        public void CreateAbility(HeroStatistic statistic)
        {
            statistic.Abilities[_id] = new AbilityModel.Builder(_name, _cooldownMulti);
        }
    }
}
