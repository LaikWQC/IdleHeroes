namespace IdleHeroes.Data
{
    public interface IJobBuilder
    {
        IAbilityBuilder AddAbility(AbilityDto ability);
    }
}
