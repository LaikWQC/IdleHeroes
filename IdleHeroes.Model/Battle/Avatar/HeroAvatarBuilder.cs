using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatarBuilder
    {
        public int Power { get; set; }
        public Dictionary<string, IAbilityBuilder> Abilities { get; } = new Dictionary<string, IAbilityBuilder>();
        public Dictionary<string, IActionBuilder> Actions { get; } = new Dictionary<string, IActionBuilder>();
        public Dictionary<EffectData, IEffectFactoryBuilder> Effects { get; } = new Dictionary<EffectData, IEffectFactoryBuilder>();
        public void Finish()
        {
            foreach (var ability in Abilities.Values)
                ability.Finish();
            foreach (var action in Actions.Values)
                action.Finish(this);
        }

        public static HeroAvatar CreateAvatar(HeroModel hero, IHeroBattleContext context)
        {
            var statistic = new HeroAvatarBuilder(); //TODO take from hero
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
