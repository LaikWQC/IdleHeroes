namespace IdleHeroes.Model
{
    public class LinkPerk : Perk
    {
        private readonly string _abilityId;
        private readonly string _actionId;

        public LinkPerk(string abilityId, string actionId)
        {
            _abilityId = abilityId;
            _actionId = actionId;
        }

        public override void Apply(HeroStatistic statistic)
        {
            if (statistic.Abilities.TryGetValue(_abilityId, out var ability) &&
                statistic.Actions.TryGetValue(_actionId, out var action))
                ability.AddAction(action.Product);
        }
    }
}
