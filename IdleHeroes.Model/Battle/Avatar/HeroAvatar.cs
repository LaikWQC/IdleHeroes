using IdleHeroes.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatar : ITarget
    {
        private IHeroBattleContext _context;

        public HeroAvatar(string name, AbilitiesContainer container, IHeroBattleContext context)
        {
            HP = new LimitedValue(100D);
            CurrentAbility = PropertyService.Instance.CreateProperty<AbilityModel>();
            Cooldown = new LimitedValue();

            Name = name;
            AbilitiesContainer = container;
            _context = context;

            OnUpdate = DoNothing;
            _context.StateChanged += OnStateChanged;
            _context.State = BattleContextStates.Hunting;
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

        public void Update(double deltaTime)
        {
            OnUpdate(deltaTime);
        }
        private Action<double> OnUpdate;

        private void OnStateChanged()
        {
            switch(_context.State)
            {
                case BattleContextStates.Idle:
                    _context.State = BattleContextStates.Hunting;
                    break;
                case BattleContextStates.Hunting:
                    RemoveAbility();
                    OnUpdate = DoNothing;
                    break;
                case BattleContextStates.Battle:
                    ChooseAbility();
                    OnUpdate = Battle;
                    break;
            }
        }
        private void ChooseAbility()
        {
            CurrentAbility.Value = AbilitiesContainer.GetAbility();
            Cooldown.Max.Value = CurrentAbility.Value.CooldownMulti / 100D;
            Cooldown.Current.Value = 0;
        }
        private void RemoveAbility()
        {
            CurrentAbility.Value = null;
            Cooldown.Max.Value = 0;
        }

        private void DoNothing(double deltaTime) { }

        private double _attackSpeed = 1 / 2D;
        private void Battle(double deltaTime)
        {
            Cooldown.Current.Value += deltaTime * _attackSpeed;
            if (!Cooldown.IsMaxed) return;

            CurrentAbility.Value.UseAbility(_context);
            ChooseAbility();
        }

        public void Dispose()
        {
            //TODO
        }
    }
}
