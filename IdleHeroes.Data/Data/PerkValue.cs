using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class PerkValue
    {
        public PerkValue(PerkData data, IEnumerable<string> tags)
        {
            Data = data;
            Tags = tags.ToList().AsReadOnly();
        }

        public PerkData Data { get; }
        public ICollection<string> Tags { get; }
    }
}
