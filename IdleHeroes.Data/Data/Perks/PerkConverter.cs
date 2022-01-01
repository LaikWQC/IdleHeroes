namespace IdleHeroes.Data
{
    public class PerkConverter
    {
        private readonly PerkDataBuilder _builder;

        public PerkConverter(DataContext context, IDataError error)
        {
            _builder = new PerkDataBuilder(context, error);
        }

        public PerkData Convert(PerkDataDto dto)
        {
            dto.CreatePerk(_builder);
            return _builder.Perk;
        }

        private class PerkDataBuilder : IPerkDataBuilder
        {
            private readonly DataContext _context;
            private IDataError _error;

            public PerkDataBuilder(DataContext context, IDataError error)
            {
                _context = context;
                _error = error;
            }

            public PerkData Perk { get; set; }

            public void AddAbilityPerk(AbilityPerkDataDto perk)
            {
                if (_context.Abiities.TryGetValue(perk.AbilityId, out var ability))
                    Perk = new AbilityPerkData(ability);
                else _error.NoAbilityError(perk.AbilityId);
            }

            public void AddActionPerk(ActionPerkDataDto perk)
            {
                if (_context.Actions.TryGetValue(perk.ActionId, out var action))
                    Perk = new ActionPerkData(action);
                else _error.NoAbilityError(perk.ActionId);
            }

            public void AddLinkPerk(LinkPerkDataDto perk)
            {
                Perk = new LinkPerkData(perk.AbilityId, perk.ActionId);
            }
        }
    }
}
