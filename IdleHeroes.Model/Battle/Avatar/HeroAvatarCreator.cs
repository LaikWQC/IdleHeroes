using System.Linq;

namespace IdleHeroes.Model
{
    public static class HeroAvatarCreator
    {
        public static HeroAvatar CreateAvatar(this HeroModel hero, IHeroBattleContext context)
        {
            var statistic = new HeroStatistic(); //TODO take from hero
            statistic.Power = 10;
            foreach (var perk in hero.GetPerks())
                perk.Apply(statistic);
            statistic.Finish();
            var container = new AbilitiesContainer(statistic.Abilities.Values.Select(x => x.Product));
            var stats = new HeroAvatarStats(hero.CurrentJob.Name, 2, 100, 5); //TODO
            return new HeroAvatar(stats, container, context);
        }
    }
}
