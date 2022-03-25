namespace IdleHeroes.Model
{
    public class DamageActionBuilder : IActionBuilder
    {
        public DamageActionBuilder(int potency)
        {
            Potency = potency;
        }

        public int Potency { get; set; }

        public ActionModel Create(HeroAvatarBuilder builder)
        {
            return new DamageActionModel(builder.Power * Potency / 100D);
        }
    }
}
