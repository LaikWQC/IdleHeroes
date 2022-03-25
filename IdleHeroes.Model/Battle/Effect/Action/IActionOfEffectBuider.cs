namespace IdleHeroes.Model
{
    public interface IActionOfEffectBuider
    {
        ActionOfEffectModel Create(HeroAvatarBuilder hero);
    }
}
