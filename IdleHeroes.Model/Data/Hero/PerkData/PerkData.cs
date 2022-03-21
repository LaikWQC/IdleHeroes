namespace IdleHeroes.Model
{
    public abstract class PerkData : IPerk
    {
        public string Id { get; }
        public int? Price { get; }
        public abstract void Apply(HeroAvatarBuilder statistic);
    }
}
