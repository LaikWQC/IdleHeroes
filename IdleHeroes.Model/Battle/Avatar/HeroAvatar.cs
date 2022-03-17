using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatar : Avatar
    {
        private IHeroBattleContext _context;

        public HeroAvatar(AvatarDto dto, AbilitiesContainer container, IHeroBattleContext context) : base(dto, container, context)
        {
            _context = context;

            SelectBehaviour();
            _context.StateChanged += SelectBehaviour;
        }

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

        private class IdleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;
            private double _maxWaitTime = 1d;
            private readonly double _hpRegen = 5d;

            public IdleBehaviour(HeroAvatar owner)
            {
                _owner = owner;                
            }

            public void Update(double deltatime) 
            {
                _owner.HP.Current.Value += _hpRegen * deltatime;
                _maxWaitTime -= deltatime;
                if (_owner.HP.IsMaxed || _maxWaitTime <= 0) 
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

            public void Update(double deltatime) { }
        }
        private class BattleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public BattleBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.ChooseAbility();
            }

            public void Update(double deltatime)
            {
                _owner.Cooldown.Current.Value += deltatime * _owner._attackSpeed;
                if (!_owner.Cooldown.IsMaxed) return;

                _owner.CurrentAbility.Value.UseAbility(_owner._context);
                if (_owner._context.State != BattleContextStates.Battle) return;
                _owner.ChooseAbility();
            }
        }
    }
}
