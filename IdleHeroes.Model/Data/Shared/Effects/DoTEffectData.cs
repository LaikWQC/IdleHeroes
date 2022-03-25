using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class DoTEffectData : ActionOfEffectData
    {
        public DoTEffectData(string id, string effectId, int potency) : base(id, effectId)
        {
            Potency = potency;
        }

        public int Potency { get; }

        public override void AddAction(HeroAvatarBuilder hero)
        {
            if (!hero.Effects.TryGetValue(EffectId, out var effect)) return;

            var builder = new DoTActionOfEffectBuider(Potency);
            effect.AddAction(builder);
            hero.EffectActions.Add(Id, builder);
        }
    }
}
