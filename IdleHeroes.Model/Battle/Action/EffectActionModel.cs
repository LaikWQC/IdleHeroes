using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class EffectActionModel : ActionModel
    {
        private readonly EffectTargetTypes _targetType;
        private EffectFactory _effectFactory;

        public EffectActionModel(EffectTargetTypes targetType, EffectFactory effectFactory) 
        {
            _targetType = targetType;
            _effectFactory = effectFactory;
        }

        public override void UseAction(IBattleContext context)
        {
            _effectFactory.ApplyEffect(context.Enemy); //TODO target by type
        }
    }
}
