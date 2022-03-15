using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class PerkValue
    {
        public PerkValue(Perk perk, IEnumerable<Tags> tags)
        {
            Perk = perk;
            Tags = tags.ToList().AsReadOnly();
        }

        public Perk Perk { get; }
        public ICollection<Tags> Tags { get; }
    }
}
