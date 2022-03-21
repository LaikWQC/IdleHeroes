using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class HeroFactoryBuilder : IHeroDataBuilder
        {
            private List<JobFactoryBuilder> _jobs = new List<JobFactoryBuilder>();

            public IJobDataBuilder CreateJob(string name)
            {
                var builder = new JobFactoryBuilder(name);
                _jobs.Add(builder);
                return builder;
            }

            public HeroFactory Create()
            {
                return new HeroFactory(_jobs.Select(x => x.Create()));
            }
        }
    }
}
