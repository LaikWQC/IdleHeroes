using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class AbilityFactoryBuilder : IAbilityDataBuilder
        {
            private readonly AbilityDto _ability;
            private List<IActionDataBuilder> _actions = new List<IActionDataBuilder>();

            public AbilityFactoryBuilder(AbilityDto ability)
            {
                _ability = ability;
            }

            public void AddDamage(int potency)
            {
                _actions.Add(new DamageActionDataBuilder(_ability.Id, potency));
            }

            public IEffectDataBuilder AddEffect(EffectDto effect)
            {
                var builder = new EffectDataBuilder(_ability.Id, effect);
                _actions.Add(builder);
                return builder;
            }

            public PerkFactory Create()
            {
                var ability = new AbilityData(_ability, _actions.Select(x => x.Create()));
                var perk = new AbilityPerk(ability);
                return new PerkFactory(perk);
            }
        }
    }
}
