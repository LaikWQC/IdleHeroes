using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class JobData
    {
        private PerksCollector _collector;

        public JobData(string name, Func<JobData, IEnumerable<PerkPoint>> createPerksDelegate, PerksCollector collector, IEnumerable<string> tags)
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

        public IEnumerable<PerkData> GetPerks(ICollection<string> tags) => _collector.GetPerks(tags);
    }
}
