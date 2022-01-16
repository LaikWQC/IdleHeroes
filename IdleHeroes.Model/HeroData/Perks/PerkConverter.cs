using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class PerkConverter
    {
        private readonly PerkBuilder _builder;

        public PerkConverter(HeroDataContext context, IDataError error)
        {
            _builder = new PerkBuilder(context, error);
        }

        public Perk Convert(PerkDto dto)
        {
            dto.CreatePerk(_builder);
            return _builder.Perk;
        }

        private class PerkBuilder : IPerkBuilder
        {
            private readonly HeroDataContext _context;
            private IDataError _error;

            public PerkBuilder(HeroDataContext context, IDataError error)
            {
                _context = context;
                _error = error;
            }

            public Perk Perk { get; set; }

            public void AddAbilityPerk(AbilityPerkDto perk)
            {
                if (_context.Abiities.TryGetValue(perk.AbilityId, out var ability))
                    Perk = new AbilityPerk(ability);
                else _error.NoAbilityError(perk.AbilityId);
            }

            public void AddActionPerk(ActionPerkDto perk)
            {
                if (_context.Actions.TryGetValue(perk.ActionId, out var action))
                    Perk = new ActionPerk(action);
                else _error.NoAbilityError(perk.ActionId);
            }

            public void AddLinkPerk(LinkPerkDto perk)
            {
                Perk = new LinkPerk(perk.AbilityId, perk.ActionId);
            }
        }
    }
}
