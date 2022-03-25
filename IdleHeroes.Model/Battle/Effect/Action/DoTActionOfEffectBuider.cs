namespace IdleHeroes.Model
{
    public class DoTActionOfEffectBuider : IActionOfEffectBuider
    {
        public DoTActionOfEffectBuider(int potency)
        {
            Potency = potency;
        }

        public int Potency { get; set; }

        public ActionOfEffectModel Create(HeroAvatarBuilder hero)
        {
            return new DoTActionOfEffect(Potency);
        }
    }
}
