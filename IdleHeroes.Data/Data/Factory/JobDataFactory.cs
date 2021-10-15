using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class JobDataFactory
    {
        private readonly string _name;
        private readonly List<string> _tags;
        private readonly List<PerkPointFactory> _perks;

        public JobDataFactory(string name, IEnumerable<string> tags, IEnumerable<PerkPointFactory> perks)
        {
            _name = name;
            _tags = tags.ToList();
            _perks = perks.ToList();
        }

        public JobData CreateJob()
        {
            var collector = new PerksCollector();
            return new JobData(_name, job => _perks.Select(x => x.CreatePerk(job, collector)), collector, _tags);
        }
    }
}
