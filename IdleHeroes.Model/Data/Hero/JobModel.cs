using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class JobModel
    {
        private PerksCollector _collector;

        public JobModel(string name, IEnumerable<PerkPointFactory> perkFactories, IEnumerable<string> tags)
        {
            Name = name;
            _collector = new PerksCollector();
            Perks = perkFactories.Select(x => x.CreatePerk(this, _collector)).ToList().AsReadOnly();
            AvailableTags = tags.ToList().AsReadOnly();
        }

        public ICollection<PerkPoint> Perks { get; }
        public ICollection<string> AvailableTags { get; }
        public string Name { get; }
        public int Experience { get; set; }

        public IEnumerable<Perk> GetPerks(ICollection<string> tags) => _collector.GetPerks(tags);
    }
}
