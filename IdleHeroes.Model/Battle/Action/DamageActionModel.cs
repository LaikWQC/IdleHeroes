namespace IdleHeroes.Model
{
    public class DamageActionModel : ActionModel
    {
        private DamageActionModel() { }

        public double Damage { get; private set; }

        public override void UseAction(ITarget target)
        {
            target.TakeDamage(MathEx.GetRandomNumber(1,Damage));
        }

        public class Builder : IActionBuilder
        {
            private readonly int _potency;

            public Builder(int potency)
            {
                _product = new DamageActionModel();
                _potency = potency;
            }

            public ActionModel Product => _product;
            private DamageActionModel _product;

            public void Finish(HeroAvatarBuilder statistic)
            {
                _product.Damage = statistic.Power * _potency / 100D;
            }
        }
    }
}
