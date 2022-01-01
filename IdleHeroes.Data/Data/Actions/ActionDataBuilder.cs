using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class ActionDataBuilder : IActionDataBuilder
    {
        public List<ActionData> Actions { get; } = new List<ActionData>();

        public void AddAction(BuffActionDto action)
        {
            Actions.Add(new BuffActionData(action.Id, action.BuffId));
        }

        public void AddAction(DamageActionDto action)
        {
            Actions.Add(new DamageActionData(action.Id, action.Potency));
        }
    }
}
