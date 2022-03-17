using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatar : Avatar
    {
        private IHeroBattleContext _context;

        public HeroAvatar(HeroAvatarStats stats, AbilitiesContainer container, IHeroBattleContext context) : base(stats, container, context)
        {
            _context = context;
            Stats = stats;

            SelectBehaviour();
            _context.StateChanged += SelectBehaviour;
        }
        public new HeroAvatarStats Stats { get; }

        protected override void Update(double deltaTime) 
        {
            _behaviour?.Update(deltaTime);
        }
        private IBehaviour _behaviour;

        private void SelectBehaviour()
        {
            switch (_context.State)
            {
                case BattleContextStates.Idle:
                    _behaviour = new IdleBehaviour(this);
                    break;
                case BattleContextStates.Hunting:
                    _behaviour = new HuntingBehaviour(this);
                    break;
                case BattleContextStates.Battle:
                    _behaviour = new BattleBehaviour(this);
                    break;
            }
        }

        private void Regen(double deltaTime)
        {
            Stats.HP.Current.Value += Stats.HpRegen * deltaTime;
        }
        private void Battle(double deltaTime)
        {
            //TODO дублирование кода, но с проверкой на State 
            CurrentAbility.Cooldown.Current.Value += deltaTime * Stats.AttackSpeed;
            if (!CurrentAbility.Cooldown.IsMaxed) return;

            CurrentAbility.Ability.Value.UseAbility(_context);
            if (_context.State != BattleContextStates.Battle) return;
            ChooseAbility();
        }

        private class IdleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;
            private double _maxWaitTime = 2d;

            public IdleBehaviour(HeroAvatar owner)
            {
                _owner = owner;                
            }

            public void Update(double deltaTime) 
            {
                _owner.Regen(deltaTime);
                _maxWaitTime -= deltaTime;
                if (_owner.Stats.HP.IsMaxed || _maxWaitTime <= 0)
                    _owner._context.State = BattleContextStates.Hunting;
            }
        }
        private class HuntingBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public HuntingBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.RemoveAbility();
            }

            public void Update(double deltaTime) { }
        }
        private class BattleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public BattleBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.ChooseAbility();
            }

            public void Update(double deltaTime)
            {
                _owner.Battle(deltaTime);
            }
        }
    }
}
