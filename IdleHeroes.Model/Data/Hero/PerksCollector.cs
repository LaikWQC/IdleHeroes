using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class PerksCollector
    {
        private Dictionary<Perk, HashSet<Tags>> _perks = new Dictionary<Perk, HashSet<Tags>>();

        public void AddPerk(Perk perk, IEnumerable<Tags> newTags)
        {
            if (!_perks.TryGetValue(perk, out var tags))
                tags = _perks[perk] = new HashSet<Tags>();
            foreach (var tag in newTags)
                tags.Add(tag);
        }

        public IEnumerable<Perk> GetPerks(ICollection<Tags> tags)
        {
            return _perks.Where(x => tags.Any(t => x.Value.Contains(t))).Select(x => x.Key);
        }
    }
}
