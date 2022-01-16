using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class ActionDataBuilder : IActionDataBuilder
    {
        public List<ActionData> Actions { get; } = new List<ActionData>();

        public void AddAction(EffectActionDto action)
        {
            Actions.Add(new EffectActionData(action.Id, action.EffectId));
        }

        public void AddAction(DamageActionDto action)
        {
            Actions.Add(new DamageActionData(action.Id, action.Potency));
        }
    }
}
