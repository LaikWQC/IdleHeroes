using IdleHeroes.Model.Services;
using LaikWQC.Utils.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleCombatRoomContext : IRoomContext
    {
        private readonly IBattleRoom _owner;

        public BattleCombatRoomContext(IBattleRoom owner)
        {
            Enemy = PropertyService.Instance.CreateProperty<Avatar>();
            State = PropertyService.Instance.CreateProperty(BattleContextStates.Idle);
            State.ValueChanged += OnStateChanged;
            _enemyBattleContext = new EnemyBattleContext(this);

            CmdMoveBack = new MyCommand(MoveBack);
            _owner = owner;

            Hero = _owner.Hero.CreateAvatar(new HeroBattleContext(this));
            Hero.Died += ()=> _owner.EnterToIdle(); 
        }

        public void Dispose()
        {
            Hero.Dispose();
            Enemy.Value?.Dispose();
        }

        private void MoveBack()
        {
            _owner.EnterToIdle();
        }
        public ICommand CmdMoveBack { get; }

        public HeroAvatar Hero { get; }
        public IProperty<Avatar> Enemy { get; }
        public IProperty<BattleContextStates> State { get; }
        private void OnStateChanged()
        {
            switch (State.Value)
            {
                case BattleContextStates.Hunting:
                    CreateNewEnemy();
                    break;
            }
        }

        private void CreateNewEnemy()
        {
            if(Enemy.Value!=null)
                Enemy.Value.Died -= CreateNewEnemy;

            Enemy.Value = new EnemyAvatar(_enemyBattleContext); //TODO
            State.Value = BattleContextStates.Battle;

            Enemy.Value.Died += CreateNewEnemy;
        }

        private EnemyBattleContext _enemyBattleContext;
        private class HeroBattleContext : IHeroBattleContext
        {
            private readonly BattleCombatRoomContext _owner;

            public HeroBattleContext(BattleCombatRoomContext owner)
            {
                _owner = owner;
            }

            public ITarget Self => _owner.Hero;
            public ITarget Enemy => _owner.Enemy.Value;
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
        private class EnemyBattleContext : IBattleContext
        {
            private readonly BattleCombatRoomContext _owner;

            public EnemyBattleContext(BattleCombatRoomContext owner)
            {
                _owner = owner;
            }

            public ITarget Self => _owner.Enemy.Value;
            public ITarget Enemy => _owner.Hero;
        }
    }
}
