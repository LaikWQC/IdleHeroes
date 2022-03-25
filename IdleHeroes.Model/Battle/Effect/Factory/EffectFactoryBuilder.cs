using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class EffectFactoryBuilder : IEffectFactoryBuilder
    {
        private EffectTargetTypes _targetType;
        private List<IActionOfEffectBuider> _actions = new List<IActionOfEffectBuider>();

        public EffectFactoryBuilder(EffectData effect)
        {
            _targetType = effect.TargetType;
            DurationType = effect.DurationType;
            Duration = effect.Duration;
        }

        public void AddAction(IActionOfEffectBuider action) 
        {
            _actions.Add(action);
        }

        public DurationTypes DurationType { get; set; }
        public int Duration { get; set; }

        public EffectFactory Create(HeroAvatarBuilder hero)
        {
            return new EffectFactory(Duration, DurationType, _actions.Select(x=>x.Create(hero)));
        }
    }
}
