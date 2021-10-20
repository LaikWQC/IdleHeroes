using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class ActionDataBuilder : IActionDataBuilder
    {
        public List<ActionData> Actions { get; } = new List<ActionData>();

        public void AddBuffAction(BuffActionDto action)
        {
            Actions.Add(new BuffActionData(action.Id, action.BuffId));
        }

        public void AddDamageAction(DamageActionDto action)
        {
            Actions.Add(new DamageActionData(action.Id, action.Potency));
        }
    }
}
