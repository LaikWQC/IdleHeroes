using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class JobFactory
    {
        private readonly List<PerkFactory> _perks;

        public JobFactory(string name, IEnumerable<PerkFactory> perks)
        {
            Name = name;
            _perks = perks.ToList();
        }

        public JobModel CreateJob()
        {
            return new JobModel(Name, _perks);
        }

        public string Name { get; }
    }
}
