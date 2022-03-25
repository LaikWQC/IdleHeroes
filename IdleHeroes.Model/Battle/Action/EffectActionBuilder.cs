using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class EffectActionBuilder : IActionBuilder
    {
        private readonly IEffectFactoryBuilder _effectFactory;

        public EffectActionBuilder(EffectTargetTypes targetType, IEffectFactoryBuilder effectFactory)
        {
            TargetType = targetType;
            _effectFactory = effectFactory;
        }

        public EffectTargetTypes TargetType { get; set; }

        public ActionModel Create(HeroAvatarBuilder hero)
        {
            return new EffectActionModel(TargetType, _effectFactory.Create(hero));
        }
    }
}
