using System;

namespace IdleHeroes.Model
{
    public interface IHeroBattleContext : IBattleContext
    {
        IProperty<BattleContextStates> State { get; }
    }
}
