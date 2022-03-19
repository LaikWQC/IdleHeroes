namespace IdleHeroes.Model
{
    public class AbilityPerk : Perk
    {
        private readonly AbilityData _ability;

        public AbilityPerk(AbilityData ability)
        {
            _ability = ability;
        }

        public override void Apply(HeroAvatarBuilder statistic)
        {
            _ability.CreateAbility(statistic);
        }
    }
}
