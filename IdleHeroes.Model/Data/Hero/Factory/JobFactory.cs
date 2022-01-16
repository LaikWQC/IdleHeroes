using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class JobFactory
    {
        private readonly List<string> _tags;
        private readonly List<PerkPointFactory> _perks;

        public JobFactory(string name, IEnumerable<string> tags, IEnumerable<PerkPointFactory> perks)
        {
            Name = name;
            _tags = tags.ToList();
            _perks = perks.ToList();
        }

        public JobModel CreateJob()
        {
            return new JobModel(Name, _perks, _tags);
        }

        public string Name { get; }
    }
}
