using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class EffectDataBuilder : IEffectDataBuilder, IActionDataBuilder
        {
            private readonly string _abilityId;
            private readonly EffectDto _effect;
            private List<ActionOfEffectData> _actions = new List<ActionOfEffectData>();

            public EffectDataBuilder(EffectDto effect, string abilityId)
            {
                _abilityId = abilityId;
                _effect = effect;
            }

            public void AddDoT(string id, int potency)
            {
                _actions.Add(new DoTEffectData(id, _effect.Id, potency));
            }

            public void AddIncomingDamage(string id, int value)
            {
                _actions.Add(new IncomingDamageEffectData(id, _effect.Id, value));
            }

            public void AddMinDamage(string id, int value)
            {
                _actions.Add(new MinDamageEffectData(id, _effect.Id, value));
            }

            public ActionData Create()
            {
                return new EffectActionData(_effect.Id, _abilityId, new EffectData(_effect, _actions));
            }
        }
    }
}
