namespace IdleHeroes.Data
{
    public interface IHeroBuilder
    {
        IJobBuilder CreateJob(string Name);
    }
}
