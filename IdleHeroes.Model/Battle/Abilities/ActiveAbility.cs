using IdleHeroes.Model.Services;

namespace IdleHeroes.Model
{
    public class ActiveAbility
    {
        public ActiveAbility()
        {
            Ability = PropertyService.Instance.CreateProperty<AbilityModel>();
            Cooldown = new LimitedValue();
        }

        public IProperty<AbilityModel> Ability { get; }
        public LimitedValue Cooldown { get; }

        public void SetAbility(AbilityModel ability)
        {
            Ability.Value = ability;
            Cooldown.Max.Value = 1;
            Cooldown.Current.Value = 0;
        }
    }
}
