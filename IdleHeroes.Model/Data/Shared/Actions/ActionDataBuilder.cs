using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public class ActionDataBuilder : IActionDataBuilder, IEffectDataBuilder
    {
        private readonly IDataError _error;

        public ActionDataBuilder(IDataError error)
        {
            _error = error;
        }

        public Dictionary<string, ActionData> Actions { get; } = new Dictionary<string, ActionData>(); 
        private Dictionary<string, EffectData> Effects { get; } = new Dictionary<string, EffectData>();

        #region Effects
        public void AddEffect(MinDamageEffectDto effect)
        {
            if (Effects.ContainsKey(effect.Id))
                _error.RepeatedEffectIdError(effect.Id);
            else Effects.Add(effect.Id, new MinDamageEffectData(effect.TargetType, effect.Duration, effect.Value));
        }
        public void AddEffect(DoTEffectDto effect)
        {
            if (Effects.ContainsKey(effect.Id))
                _error.RepeatedEffectIdError(effect.Id);
            else Effects.Add(effect.Id, new DoTEffectData(effect.TargetType, effect.Duration, effect.Potency));
        }
        public void AddEffect(IncomingDamageEffectDto effect)
        {
            if (Effects.ContainsKey(effect.Id))
                _error.RepeatedEffectIdError(effect.Id);
            else Effects.Add(effect.Id, new IncomingDamageEffectData(effect.TargetType, effect.Duration, effect.Value));
        }
        #endregion

        #region Actions
        public void AddAction(EffectActionDto action)
        {
            if (Actions.ContainsKey(action.Id))
            {
                _error.RepeatedActionIdError(action.Id);
                return;
            }                
            if (!Effects.TryGetValue(action.EffectId, out var effect))
            {
                _error.NoEffectError(action.EffectId);
                return;
            }                
            Actions.Add(action.Id, new EffectActionData(action.Id, effect));
        }
        public void AddAction(DamageActionDto action)
        {
            if (Actions.ContainsKey(action.Id))
                _error.RepeatedActionIdError(action.Id);
            else Actions.Add(action.Id, new DamageActionData(action.Id, action.Potency));
        }
        #endregion
    }
}
