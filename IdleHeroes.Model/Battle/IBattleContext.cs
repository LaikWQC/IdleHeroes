namespace IdleHeroes.Model
{
    public interface IBattleContext
    {
        ITarget Self { get; }
        ITarget Enemy { get; }
    }
    public enum BattleContextStates
    {
        Idle,
        Hunting,
        Battle
    }
}
