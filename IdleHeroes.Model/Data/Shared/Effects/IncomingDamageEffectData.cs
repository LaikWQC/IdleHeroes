using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class IncomingDamageEffectData : ActionOfEffectData
    {
        public IncomingDamageEffectData(string id, string effectId, int value) : base(id, effectId)
        {
            Value = value;
        }

        public int Value { get; }

        public override void AddAction(HeroAvatarBuilder hero)
        {
            if (!hero.Effects.TryGetValue(EffectId, out var effect)) return;

            var builder = new IncomingDamageActionOfEffectBuider(Value);
            effect.AddAction(builder);
            hero.EffectActions.Add(Id, builder);
        }
    }
}
