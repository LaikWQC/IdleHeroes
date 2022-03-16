using LaikWQC.Utils.Commands;
using System;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleCombatRoomContext : IRoomContext
    {
        private readonly IBattleRoom _owner;

        public BattleCombatRoomContext(IBattleRoom owner)
        {
            CmdMoveBack = new MyCommand(MoveBack);
            _owner = owner;
            _heroContext = new HeroBattleContext(this);

            Hero = _owner.Hero.CreateAvatar(_heroContext);
        }

        public void Dispose()
        {
            //TODO
        }

        private void MoveBack()
        {
            _owner.EnterToIdle();
        }
        public ICommand CmdMoveBack { get; }

        public HeroAvatar Hero { get; }
        public ITarget Enemy { get; set; }
        private BattleContextStates State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                StateChanged?.Invoke();

                switch(_state)
                {
                    case BattleContextStates.Hunting:
                        Enemy = new Dummy(); //TODO
                        State = BattleContextStates.Battle;
                        break;
                }
            }
        }
        private BattleContextStates _state;
        private event Action StateChanged;

        private HeroBattleContext _heroContext;
        private class HeroBattleContext : IHeroBattleContext
        {
            private readonly BattleCombatRoomContext _owner;

            public HeroBattleContext(BattleCombatRoomContext owner)
            {
                _owner = owner;
            }

            public ITarget Self => _owner.Hero;
            public ITarget Enemy => _owner.Enemy;
            public BattleContextStates State 
            {
                get => _owner.State;
                set => _owner.State = value;
            }
            public event Action StateChanged
            {
                add => _owner.StateChanged += value;
                remove => _owner.StateChanged -= value;
            }
        }
        private class Dummy : ITarget
        {
            public void ApplyEffect(EffectModel effect) { }
            public void TakeDamage(double damage) { }
        }
    }
}
