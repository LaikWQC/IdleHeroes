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
            CurrentHp = PropertyService.Instance.CreateProperty(100D);
            CurrentAbility = PropertyService.Instance.CreateProperty<AbilityModel>();
            CurrentCooldown = PropertyService.Instance.CreateProperty<double>();

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
        public IProperty<double> CurrentCooldown { get; }
        public IProperty<double> CurrentHp { get; }
        public event Action Died;

        public void TakeDamage(double damage)
        {
            CurrentHp.Value -= damage;
            if (CurrentHp.Value <= 0)
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
                    CurrentAbility.Value = null;
                    CurrentCooldown.Value = 0;
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
            CurrentCooldown.Value = _attackCooldown * CurrentAbility.Value.CooldownMulti / 100;
        }

        private void DoNothing(double deltaTime) { }

        private double _attackCooldown = 2D;
        private void Battle(double deltaTime)
        {
            CurrentCooldown.Value -= deltaTime;
            if (CurrentCooldown.Value > 0) return;

            CurrentAbility.Value.UseAbility(_context);
            ChooseAbility();
        }

        public void Dispose()
        {
            //TODO
        }
    }
}
