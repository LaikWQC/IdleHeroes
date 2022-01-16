using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class PerkValue
    {
        public PerkValue(Perk perk, IEnumerable<string> tags)
        {
            Perk = perk;
            Tags = tags.ToList().AsReadOnly();
        }

        public Perk Perk { get; }
        public ICollection<string> Tags { get; }
    }
}
