using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public interface IAbilityBuilder
    {
        void AddAction(IActionBuilder action);
        ChanceTypes ChanceType { get; set; }
        int Chance { get; set; }
        AbilityModel Create(HeroAvatarBuilder hero);
    }
}
