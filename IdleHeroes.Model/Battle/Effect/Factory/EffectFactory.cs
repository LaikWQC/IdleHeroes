using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class EffectFactory
    {
        private List<ActionOfEffectModel> _actions;
        public EffectFactory(int duration, DurationTypes durationType, IEnumerable<ActionOfEffectModel> actions)
        {
            Duration = duration;
            DurationType = durationType;
            _actions = actions.ToList();
        }

        public DurationTypes DurationType { get; }
        public int Duration { get; }
        public void ApplyEffect(ITarget target)
        {
            target.ApplyEffect(new EffectModel(_actions));
        }
    }
}
