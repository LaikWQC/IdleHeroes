using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatarBuilder
    {
        public int Power { get; set; }
        public Dictionary<string, IAbilityBuilder> Abilities { get; } = new Dictionary<string, IAbilityBuilder>();
        public Dictionary<string, IActionBuilder> Actions { get; } = new Dictionary<string, IActionBuilder>();
        public Dictionary<string, IEffectFactoryBuilder> Effects { get; } = new Dictionary<string, IEffectFactoryBuilder>();
        public Dictionary<string, IActionOfEffectBuider> EffectActions { get; } = new Dictionary<string, IActionOfEffectBuider>();

        public static HeroAvatar CreateAvatar(HeroModel hero, IHeroBattleContext context)
        {
            var builder = new HeroAvatarBuilder(); //TODO take from hero
            builder.Power = 10;
            foreach (var perk in hero.GetPerks())
                perk.Apply(builder);
            
            var container = new AbilitiesContainer(builder.Abilities.Values.Select(x => x.Create(builder)));
            var stats = new HeroAvatarStats(hero.CurrentJob.Name, 2, 100, 5); //TODO
            return new HeroAvatar(stats, container, context);
        }
    }
}
