namespace IdleHeroes.Model
{
    public class IncomingDamageActionOfEffectBuider : IActionOfEffectBuider
    {
        public IncomingDamageActionOfEffectBuider(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public ActionOfEffectModel Create(HeroAvatarBuilder hero)
        {
            return new IncomingDamageActionOfEffect(Value);
        }
    }
}
