using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IdleHeroes.Model
{
    public class HeroAvatar : Avatar
    {
        public HeroAvatar(HeroAvatarStats stats, AbilitiesContainer container, IHeroBattleContext context) : base(stats, container, context)
        {
            BattleContext = context;
            Stats = stats;

            SelectBehaviour();
            BattleContext.State.ValueChanged += SelectBehaviour;
        }
        public IHeroBattleContext BattleContext { get; }
        public new HeroAvatarStats Stats { get; }

        protected override void Update() 
        {
            _behaviour?.Update();
        }
        private IBehaviour _behaviour;

        private void SelectBehaviour()
        {
            _behaviour?.Exit();
            switch (BattleContext.State.Value)
            {
                case BattleContextStates.Safe:
                    _behaviour = new SafeBehaviour(this);
                    break;
                case BattleContextStates.Idle:
                    _behaviour = new IdleBehaviour(this);
                    break;
                case BattleContextStates.Hunting:
                    _behaviour = new HuntingBehaviour(this);
                    break;
                case BattleContextStates.Battle:
                    _behaviour = new BattleBehaviour(this);
                    break;
                default: return;
            }
            _behaviour.Enter();
        }

        private void Regen(double multi = 1)
        {
            Stats.HP.Current.Value += Stats.HpRegen * multi * DeltaTime;
        }
        private void Battle()
        {
            //TODO дублирование кода, но с проверкой на State 
            CurrentAbility.Cooldown.Current.Value += DeltaTime * Stats.AttackSpeed;
            if (!CurrentAbility.Cooldown.IsMaxed) return;

            CurrentAbility.Ability.Value.UseAbility(BattleContext, _token);
            if (BattleContext.State.Value != BattleContextStates.Battle) return;
            ChooseAbility();
        }

        private class SafeBehaviour: IBehaviour
        {
            private readonly HeroAvatar _owner;

            public SafeBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.RemoveAbility();
            }

            public void Enter() { }
            public void Update()
            {
                _owner.Regen();
            }
            public void Exit() { }
        }
        private class IdleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public IdleBehaviour(HeroAvatar owner)
            {
                _owner = owner; 
                _owner.RemoveAbility();
            }

            public void Enter() 
            {
                _owner.BattleContext.State.Value = BattleContextStates.Hunting;
            }
            public void Update() { }
            public void Exit() { }
        }
        private class HuntingBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public HuntingBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.RemoveAbility();
            }

            public void Enter() { }
            public void Update() 
            {
                _owner.Regen(0.5);
            }
            public void Exit() { }
        }
        private class BattleBehaviour : IBehaviour
        {
            private readonly HeroAvatar _owner;

            public BattleBehaviour(HeroAvatar owner)
            {
                _owner = owner;
                _owner.ChooseAbility();
            }

            public void Enter() 
            {
                _owner.CreateToken();

            }
            public void Update()
            {
                _owner.Battle();
            }
            public void Exit() 
            {
                _owner.CancelToken();
            }
        }
    }
}
