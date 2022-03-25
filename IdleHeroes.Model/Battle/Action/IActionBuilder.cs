namespace IdleHeroes.Model
{
    public interface IActionBuilder
    {
        ActionModel Create(HeroAvatarBuilder hero);
    }
}
