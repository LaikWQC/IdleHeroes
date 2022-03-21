using IdleHeroes.Data;
using System.Collections.Generic;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class EffectDataBuilder : IEffectDataBuilder, IActionDataBuilder
        {
            private readonly string _id;
            private readonly EffectDto _effect;
            private List<EffectAction> _actions;

            public EffectDataBuilder(string id, EffectDto effect)
            {
                _id = id;
                _effect = effect;
            }

            public void AddDoT(int potency)
            {
                _actions.Add(new DoTEffectData(potency));
            }

            public void AddIncomingDamage(int value)
            {
                _actions.Add(new IncomingDamageEffectData(value));
            }

            public void AddMinDamage(int value)
            {
                _actions.Add(new MinDamageEffectData(value));
            }

            public ActionData Create()
            {
                return new EffectActionData(_id, new EffectData(_effect, _actions));
            }
        }
    }
}
