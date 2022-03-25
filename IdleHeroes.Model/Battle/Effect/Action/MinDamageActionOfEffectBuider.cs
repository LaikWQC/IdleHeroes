namespace IdleHeroes.Model
{
    public class MinDamageActionOfEffectBuider : IActionOfEffectBuider
    {
        public MinDamageActionOfEffectBuider(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public ActionOfEffectModel Create(HeroAvatarBuilder hero)
        {
            return new MinDamageActionOfEffect(Value);
        }
    }
}
