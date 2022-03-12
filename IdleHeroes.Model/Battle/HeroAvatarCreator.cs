using System.Linq;

namespace IdleHeroes.Model
{
    public static class HeroAvatarCreator
    {
        public static HeroAvatar CreateAvatar(this HeroModel hero)
        {
            var statistic = new HeroStatistic(); //TODO take from hero
            statistic.Power = 10;
            foreach(var perk in hero.GetPerks())
                perk.Apply(statistic);
            statistic.Finish();
            return new HeroAvatar(statistic.Abilities.Values.Select(x => x.Product));
        }
    }
}
