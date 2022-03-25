namespace IdleHeroes.Data
{
    public interface IHeroDataBuilder
    {
        IJobDataBuilder CreateJob(string name);
    }
}
