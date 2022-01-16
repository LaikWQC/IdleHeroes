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
    }
}
