using IdleHeroes.Model.Services;
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
            State = PropertyService.Instance.CreateProperty(BattleContextStates.Idle);
            State.ValueChanged += OnStateChanged;

            CmdMoveBack = new MyCommand(MoveBack);
            _owner = owner;
            _heroContext = new HeroBattleContext(this);

            Hero = _owner.Hero.CreateAvatar(_heroContext);
        }

        public void Dispose()
        {
            Hero.Dispose();
            //Enemy?.Dispose();
        }

        private void MoveBack()
        {
            _owner.EnterToIdle();
        }
        public ICommand CmdMoveBack { get; }

        public HeroAvatar Hero { get; }
        public ITarget Enemy { get; set; }
        public IProperty<BattleContextStates> State { get; }
        private void OnStateChanged()
        {
            switch (State.Value)
            {
                case BattleContextStates.Hunting:
                    Enemy = new Dummy(); //TODO
                    State.Value = BattleContextStates.Battle;
                    break;
            }
        }

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
                get => _owner.State.Value;
                set => _owner.State.Value = value;
            }
            public event Action StateChanged
            {
                add => _owner.State.ValueChanged += value;
                remove => _owner.State.ValueChanged -= value;
            }
        }
        private class Dummy : ITarget
        {
            public void ApplyEffect(EffectModel effect) { }
            public void TakeDamage(double damage) { }
        }
    }
}
