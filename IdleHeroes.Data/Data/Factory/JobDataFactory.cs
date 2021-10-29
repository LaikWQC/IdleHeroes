using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class JobDataFactory
    {
        private readonly List<string> _tags;
        private readonly List<PerkPointFactory> _perks;

        public JobDataFactory(string name, IEnumerable<string> tags, IEnumerable<PerkPointFactory> perks)
        {
            Name = name;
            _tags = tags.ToList();
            _perks = perks.ToList();
        }

        public JobData CreateJob()
        {
            var collector = new PerksCollector();
            return new JobData(Name, job => _perks.Select(x => x.CreatePerk(job, collector)), collector, _tags);
        }

        public string Name { get; }
    }
}
