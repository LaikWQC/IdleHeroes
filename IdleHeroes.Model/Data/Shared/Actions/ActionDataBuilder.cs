using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class ActionDataBuilder : IActionDataBuilder
    {
        private readonly IDataError _error;

        public ActionDataBuilder(IDataError error)
        {
            _error = error;
        }

        public Dictionary<string, ActionData> Actions { get; } = new Dictionary<string, ActionData>();

        public void AddAction(EffectActionDto action)
        {
            if (Actions.ContainsKey(action.Id))
                _error.RepeatedActionIdError(action.Id);
            else Actions.Add(action.Id, new EffectActionData(action.Id, action.EffectId));
        }

        public void AddAction(DamageActionDto action)
        {
            if (Actions.ContainsKey(action.Id))
                _error.RepeatedActionIdError(action.Id);
            else Actions.Add(action.Id, new DamageActionData(action.Id, action.Potency));
        }
    }
}
