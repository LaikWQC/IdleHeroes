using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class PerkDataBuilder : IPerkDataBuilder
    {
        private readonly DataContext _context;
        private readonly IDataError _error;

        public PerkDataBuilder(DataContext context, IDataError error)
        {
            _context = context;
            _error = error;
        }

        public List<PerkData> Perks { get; } = new List<PerkData>();

        public void AddAbilityPerk(AbilityPerkDataDto perk)
        {
            if (_context.Abiities.TryGetValue(perk.AbilityId, out var ability))
                Perks.Add(new AbilityPerkData(ability));
            else _error.NoAbilityError(perk.AbilityId);
        }

        public void AddActionPerk(ActionPerkDataDto perk)
        {
            if (_context.Actions.TryGetValue(perk.ActionId, out var action))
                Perks.Add(new ActionPerkData(action));
            else _error.NoAbilityError(perk.ActionId);
        }

        public void AddLinkPerk(LinkPerkDataDto perk)
        {
            Perks.Add(new LinkPerkData(perk.AbilityId, perk.ActionId));
        }
    }
}
