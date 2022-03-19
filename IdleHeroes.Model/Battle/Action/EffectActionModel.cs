namespace IdleHeroes.Model
{
    public class EffectActionModel : ActionModel
    {
        private EffectFactory _effectFactory;

        private EffectActionModel(EffectFactory effectFactory) 
        {
            _effectFactory = effectFactory;
        }

        public override void UseAction(ITarget target)
        {
            _effectFactory.ApplyEffect(target);
        }

        public class Builder : IActionBuilder
        {
            public Builder(EffectFactory effectFactory)
            {
                _product = new EffectActionModel(effectFactory);
            }

            public ActionModel Product => _product;
            private EffectActionModel _product;

            public void Finish(HeroAvatarBuilder statistic) { }
        }
    }
}
