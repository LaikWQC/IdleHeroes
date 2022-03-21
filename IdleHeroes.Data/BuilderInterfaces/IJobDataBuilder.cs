namespace IdleHeroes.Data
{
    public interface IJobDataBuilder
    {
        IAbilityDataBuilder AddAbility(AbilityDto ability);
    }
}
