namespace IdleHeroes.Model
{
    public class AbilityData
    {
        private readonly string _name;
        private readonly string _id;
        private readonly int _cooldownMulti;
        private readonly int? _chance;

        public AbilityData(string name, string id, int cooldownMulti, int? chance)
        {
            _name = name;
            _id = id;
            _cooldownMulti = cooldownMulti;
            _chance = chance;
        }

        public void CreateAbility(HeroStatistic statistic)
        {
            statistic.Abilities[_id] = new AbilityModel.Builder(_name, _cooldownMulti, _chance);
        }
    }
}
