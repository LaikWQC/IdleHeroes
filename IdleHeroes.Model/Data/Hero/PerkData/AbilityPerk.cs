using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class AbilityPerk : PerkData
    {
        private readonly AbilityData _ability;

        public AbilityPerk(PerkDto perk, AbilityData ability) : base(perk)
        {
            _ability = ability;
        }

        public override void Apply(HeroAvatarBuilder hero)
        {
            _ability.AddAbility(hero);
        }
    }
}
