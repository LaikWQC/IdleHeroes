using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroStatistic
    {
        public int Power { get; set; }
        public Dictionary<string, IAbilityBuilder> Abilities { get; } = new Dictionary<string, IAbilityBuilder>();
        public Dictionary<string, IActionBuilder> Actions { get; } = new Dictionary<string, IActionBuilder>();
        public Dictionary<EffectData, IEffectFactoryBuilder> Effects { get; } = new Dictionary<EffectData, IEffectFactoryBuilder>();
        public void Finish()
        {
            foreach (var action in Actions.Values)
                action.Finish(this);
        }
    }
}
