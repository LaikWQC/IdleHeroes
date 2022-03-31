using IdleHeroes.Model.Time;
using System;
using System.Threading;

namespace IdleHeroes.Model
{
    public abstract class Avatar : TimeObject, ITarget
    {
        private IBattleContext _context;
        protected double _attackSpeed;
        private CancellationTokenSource _cts;
        protected CancellationToken _token;

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
            Died?.Invoke();
        }

        public void ApplyEffect(EffectModel effect)
        {
            //TODO
        }

        protected override void Update()
        {
            Battle();
        }

        protected void Battle()
        {
            CurrentAbility.Cooldown.Current.Value += DeltaTime * Stats.AttackSpeed;
            if (!CurrentAbility.Cooldown.IsMaxed) return;

            CurrentAbility.Ability.Value.UseAbility(_context, _token);
            if (_token.IsCancellationRequested) return;
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

        protected void CreateToken()
        {
            _cts = new CancellationTokenSource();
            _token = _cts.Token;
        }
        protected void CancelToken()
        {
            _cts?.Cancel();
        }
    }
}
