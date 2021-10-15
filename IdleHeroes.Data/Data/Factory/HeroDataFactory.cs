using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class HeroDataFactory
    {
        private List<JobDataFactory> _jobs;

        public HeroDataFactory(IEnumerable<JobDataFactory> jobs)
        {
            _jobs = jobs.ToList();
        }

        public HeroData CreateHero(string jobName)
        {
            var hero = new HeroData(_jobs.Select(x => x.CreateJob()));
            hero.ChangeJob(jobName);
            return hero;
        }
    }
}
