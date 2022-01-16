using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class JobModel
    {
        private PerksCollector _collector;

        public JobModel(string name, Func<JobModel, IEnumerable<PerkPoint>> createPerksDelegate, PerksCollector collector, IEnumerable<string> tags)
        {
            Name = name;
            Perks = createPerksDelegate(this).ToList().AsReadOnly();
            _collector = collector;
            AvailableTags = tags.ToList().AsReadOnly();
        }

        public ICollection<PerkPoint> Perks { get; }
        public ICollection<string> AvailableTags { get; }
        public string Name { get; }
        public int Experience { get; set; }

        public IEnumerable<Perk> GetPerks(ICollection<string> tags) => _collector.GetPerks(tags);
    }
}
