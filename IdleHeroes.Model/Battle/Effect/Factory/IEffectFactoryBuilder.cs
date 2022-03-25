namespace IdleHeroes.Model
{
    public interface IEffectFactoryBuilder
    {
        void AddAction(IActionOfEffectBuider action);
        EffectFactory Create(HeroAvatarBuilder hero);
    }
}
