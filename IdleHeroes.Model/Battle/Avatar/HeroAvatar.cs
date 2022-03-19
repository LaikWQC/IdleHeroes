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

        protected override void Update() 
        {
            _behaviour?.Update();
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

        private void Regen()
        {
            Stats.HP.Current.Value += Stats.HpRegen * DeltaTime;
        }
        private void Battle()
        {
            //TODO дублирование кода, но с проверкой на State 
            CurrentAbility.Cooldown.Current.Value += DeltaTime * Stats.AttackSpeed;
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

            public void Update() 
            {
                _owner.Regen();
                _maxWaitTime -= _owner.DeltaTime;
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

            public void Update() { }
        }
        private class BattleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public BattleBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.ChooseAbility();
            }

            public void Update()
            {
                _owner.Battle();
            }
        }
    }
}
