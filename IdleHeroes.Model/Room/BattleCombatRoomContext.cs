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

        public BattleCombatRoomContext(IBattleRoom owner, HeroAvatar avatar, HeroBattleContext heroBattleContext)
        {
            Enemy = PropertyService.Instance.CreateProperty<Avatar>();            
            OnUpdate = DoNothing;
            CmdMoveBack = new MyCommand(EnterToIdle);
            
            _owner = owner;
            BattleContext = heroBattleContext;
            BattleContext.State.ValueChanged += OnStateChanged;
            Enemy.ValueChanged += () => BattleContext.Enemy = Enemy.Value;
            Hero = avatar;
            Hero.Died += EnterToIdle;

            BattleContext.State.Value = BattleContextStates.Idle;
        }

        public override void Dispose()
        {
            base.Dispose();
            Hero.Died -= EnterToIdle;
            Enemy.Value?.Dispose();
        }
        private void EnterToIdle() => _owner.EnterToIdle(Hero, BattleContext);
        public ICommand CmdMoveBack { get; }

        public HeroAvatar Hero { get; }
        public HeroBattleContext BattleContext { get; }
        public IProperty<Avatar> Enemy { get; }

        private void OnStateChanged()
        {
            switch (BattleContext.State.Value)
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
            BattleContext.State.Value = BattleContextStates.Battle;
        }

        protected void DoNothing() { }

        private void CreateNewEnemy()
        {
            if (Enemy.Value != null) 
            {
                Enemy.Value.Dispose();
                Enemy.Value.Died -= OnEnemyDied;
            }                

            Enemy.Value = new EnemyAvatar(new EnemyBattleContext(this)); 
            Enemy.Value.Died += OnEnemyDied;
        }
        private void OnEnemyDied()
        {
            Enemy.Value.Dispose();
            Enemy.Value = null;
            BattleContext.State.Value = BattleContextStates.Idle;
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
