using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public abstract class PerkData : IPerk
    {
        public PerkData(PerkDto perk)
        {
            Id = perk.Id;
            Price = perk.Price;
            ShareType = perk.ShareType;
        }
        public string Id { get; }
        public int? Price { get; }
        public PerkShareTypes ShareType { get; }
        public abstract void Apply(HeroAvatarBuilder hero);
    }
}
