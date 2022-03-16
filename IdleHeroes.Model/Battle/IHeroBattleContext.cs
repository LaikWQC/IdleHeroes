using System;

namespace IdleHeroes.Model
{
    public interface IHeroBattleContext : IBattleContext
    {
        public BattleContextStates State { get ; set ; }

        public event Action StateChanged;
    }
    public enum BattleContextStates
    {
        Idle,
        Hunting,
        Battle
    }
}
