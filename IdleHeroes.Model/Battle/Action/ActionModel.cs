namespace IdleHeroes.Model
{
    public interface IActionBuilder
    {
        ActionModel Product { get; }
        void Finish(HeroStatistic statistic);
    }

    public abstract class ActionModel
    {
        public abstract void UseAction(ITarget target);
    }
}
