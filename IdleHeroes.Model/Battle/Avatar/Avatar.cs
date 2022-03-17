using IdleHeroes.Model.Services;
using IdleHeroes.Model.Time;
using System;

namespace IdleHeroes.Model
{
    public abstract class Avatar : TimeObject, ITarget
    {
        private IBattleContext _context;
        protected double _attackSpeed;

        public Avatar(AvatarStats stats, AbilitiesContainer container, IBattleContext context)
        {
            CurrentAbility = PropertyService.Instance.CreateProperty<AbilityModel>();
            Cooldown = new LimitedValue();

            Stats = stats;
            AbilitiesContainer = container;
            _context = context;
        }

        public AvatarStats Stats { get; }
        public AbilitiesContainer AbilitiesContainer { get; }
        public IProperty<AbilityModel> CurrentAbility { get; }
        public LimitedValue Cooldown { get; }
        public event Action Died;

        public void TakeDamage(double damage)
        {
            Stats.HP.Current.Value -= damage;
            if (Stats.HP.IsMined)
                Die();
        }
        private void Die()
        {
            Dispose();
            Died?.Invoke();
        }

        public void ApplyEffect(EffectModel effect)
        {
            //TODO
        }

        protected override void Update(double deltaTime)
        {
            Cooldown.Current.Value += deltaTime * Stats.AttackSpeed;
            if (!Cooldown.IsMaxed) return;

            CurrentAbility.Value.UseAbility(_context);
            ChooseAbility();
        }

        protected void ChooseAbility()
        {
            CurrentAbility.Value = AbilitiesContainer.GetAbility();
            Cooldown.Max.Value = CurrentAbility.Value.CooldownMulti / 100D;
            Cooldown.Current.Value = 0;
        }        
        protected void RemoveAbility()
        {
            CurrentAbility.Value = null;
            Cooldown.Max.Value = 0;
        }
    }
}
