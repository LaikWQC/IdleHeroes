using IdleHeroes.Model.Services;
using IdleHeroes.Model.Time;
using LaikWQC.Utils.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleCombatRoomContext : TimeObject, IRoomContext
    {
        private readonly IBattleRoom _owner;

        public BattleCombatRoomContext(IBattleRoom owner)
        {
            Enemy = PropertyService.Instance.CreateProperty<Avatar>();
            State = PropertyService.Instance.CreateProperty(BattleContextStates.Idle);
            OnUpdate = DoNothing;
            State.ValueChanged += OnStateChanged;
            _enemyBattleContext = new EnemyBattleContext(this);
            CmdMoveBack = new MyCommand(MoveBack);
            
            _owner = owner;

            Hero = _owner.Hero.CreateAvatar(new HeroBattleContext(this));
            Hero.Died += ()=> _owner.EnterToIdle();
        }

        public override void Dispose()
        {
            base.Dispose();
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
                    _timeToSpawn = 1; //TODO
                    OnUpdate = Spawn;
                    break;
                default: 
                    OnUpdate = DoNothing;
                    break;
            }
        }

        protected override void Update()
        {
            OnUpdate?.Invoke();
        }
        protected Action OnUpdate;

        private double _timeToSpawn;
        protected void Spawn()
        {
            _timeToSpawn -= DeltaTime;
            if (_timeToSpawn > 0) return;
            CreateNewEnemy();
            State.Value = BattleContextStates.Battle;
        }

        protected void DoNothing() { }

        private void CreateNewEnemy()
        {
            if(Enemy.Value!=null)
            {
                Enemy.Value.Dispose();
                Enemy.Value.Died -= OnEnemyDied;
            }                

            Enemy.Value = new EnemyAvatar(_enemyBattleContext); //TODO
            Enemy.Value.Died += OnEnemyDied;
        }
        private void OnEnemyDied()
        {
            Enemy.Value = null;
            State.Value = BattleContextStates.Idle;
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
