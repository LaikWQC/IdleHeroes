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
            if (ability == null)
                Cooldown.Max.Value = 0;
            else
            {
                Cooldown.Max.Value = ability.CooldownMulti / 100D;
                Cooldown.Current.Value = 0;
            }            
        }
    }
}
