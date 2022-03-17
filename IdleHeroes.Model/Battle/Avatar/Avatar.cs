using IdleHeroes.Model.Services;
using IdleHeroes.Model.Time;
using System;

namespace IdleHeroes.Model
{
    public abstract class Avatar : TimeObject, ITarget
    {
        private IBattleContext _context;

        public Avatar(AvatarDto dto, AbilitiesContainer container, IBattleContext context)
        {
            HP = new LimitedValue(dto.HP);
            CurrentAbility = PropertyService.Instance.CreateProperty<AbilityModel>();
            Cooldown = new LimitedValue();

            Name = dto.Name;
            AbilitiesContainer = container;
            _context = context;
            _attackSpeed = 1 / dto.AttackCooldown;
        }

        public string Name { get; }
        public AbilitiesContainer AbilitiesContainer { get; }
        public IProperty<AbilityModel> CurrentAbility { get; }
        public LimitedValue Cooldown { get; }
        public LimitedValue HP { get; }
        public event Action Died;

        public void TakeDamage(double damage)
        {
            HP.Current.Value -= damage;
            if (HP.IsMined)
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
            Battle(deltaTime);
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

        private double _attackSpeed;
        protected void Battle(double deltaTime)
        {
            Cooldown.Current.Value += deltaTime * _attackSpeed;
            if (!Cooldown.IsMaxed) return;

            CurrentAbility.Value.UseAbility(_context);
            ChooseAbility();
        }

        protected void DoNothing(double deltaTime) { }
    }
}
