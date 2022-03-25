using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class AbilityFactoryBuilder : IAbilityDataBuilder
        {
            private readonly PerkDto _perk;
            private readonly AbilityDto _ability;
            private List<IActionDataBuilder> _actions = new List<IActionDataBuilder>();

            public AbilityFactoryBuilder(PerkDto perk, AbilityDto ability)
            {
                _perk = perk;
                _ability = ability;
            }

            public void AddDamage(string id, int potency)
            {
                _actions.Add(new DamageActionDataBuilder(id, _ability.Id, potency));
            }

            public IEffectDataBuilder AddEffect(EffectDto effect)
            {
                var builder = new EffectDataBuilder(effect, _ability.Id);
                _actions.Add(builder);
                return builder;
            }

            public PerkFactory Create()
            {
                var ability = new AbilityData(_ability, _actions.Select(x => x.Create()));
                var perk = new AbilityPerk(_perk, ability);
                return new PerkFactory(perk);
            }
        }
    }
}
