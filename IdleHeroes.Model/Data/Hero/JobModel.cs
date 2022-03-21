using IdleHeroes.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class JobModel
    {
        public JobModel(string name, IEnumerable<PerkFactory> perkFactories)
        {
            Name = name;
            Perks = perkFactories.Select(x => x.CreatePerk(this)).ToList().AsReadOnly();
        }

        public ICollection<Perk> Perks { get; }
        public string Name { get; }
        public int Experience { get; set; }
    }
}
