namespace IdleHeroes.Data
{
    public class LinkPerkData : PerkData
    {
        private readonly string _abilityId;
        private readonly string _actionId;

        public LinkPerkData(string abilityId, string actionId)
        {
            _abilityId = abilityId;
            _actionId = actionId;
        }
    }
}
