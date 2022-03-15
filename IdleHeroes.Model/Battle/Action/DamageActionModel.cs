namespace IdleHeroes.Model
{
    public class DamageActionModel : ActionModel
    {
        private DamageActionModel() { }

        public double Damage { get; private set; }

        public override void UseAction()
        {
            //TODO
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

            public void Finish(HeroStatistic statistic)
            {
                _product.Damage = statistic.Power * _potency / 100D;
            }
        }
    }
}
