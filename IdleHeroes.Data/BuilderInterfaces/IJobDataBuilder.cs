namespace IdleHeroes.Data
{
    public interface IJobDataBuilder
    {
        IAbilityDataBuilder AddAbilityPerk(PerkDto perk, AbilityDto ability);
    }
}
