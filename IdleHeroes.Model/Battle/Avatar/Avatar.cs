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
            CurrentAbility = new ActiveAbility();

            Stats = stats;
            AbilitiesContainer = container;
            _context = context;
        }

        public AvatarStats Stats { get; }
        public AbilitiesContainer AbilitiesContainer { get; }
        public ActiveAbility CurrentAbility { get; }

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

        protected override void Update()
        {
            CurrentAbility.Cooldown.Current.Value += DeltaTime * Stats.AttackSpeed;
            if (!CurrentAbility.Cooldown.IsMaxed) return;

            CurrentAbility.Ability.Value.UseAbility(_context);
            ChooseAbility();
        }

        protected void ChooseAbility()
        {
            CurrentAbility.SetAbility(AbilitiesContainer.GetAbility());
        }        
        protected void RemoveAbility()
        {
            CurrentAbility.SetAbility(null);
        }
    }
}
