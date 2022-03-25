using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroFactory
    {
        private List<JobFactory> _jobs;

        public HeroFactory(IEnumerable<JobFactory> jobs)
        {
            _jobs = jobs.ToList();
        }

        public List<string> GetAvailableJobs() => _jobs.Select(x => x.Name).ToList();

        public HeroModel CreateHero(string jobName)
        {
            var hero = new HeroModel(_jobs.Select(x => x.CreateJob()));
            hero.ChangeJob(jobName);
            return hero;
        }
    }
}
