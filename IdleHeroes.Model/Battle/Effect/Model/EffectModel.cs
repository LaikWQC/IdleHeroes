using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class EffectModel
    {
        private List<ActionOfEffectModel> _actions;
        public EffectModel(IEnumerable<ActionOfEffectModel> actions)
        {
            _actions = actions.ToList();
        }
    }
}
