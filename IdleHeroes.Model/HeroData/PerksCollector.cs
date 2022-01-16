using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class PerksCollector
    {
        private Dictionary<Perk, HashSet<string>> _perks = new Dictionary<Perk, HashSet<string>>();

        public void AddPerk(Perk perk, IEnumerable<string> newTags)
        {
            if (!_perks.TryGetValue(perk, out var tags))
                tags = _perks[perk] = new HashSet<string>();
            foreach (var tag in newTags)
                tags.Add(tag);
        }

        public IEnumerable<Perk> GetPerks(ICollection<string> tags)
        {
            return _perks.Where(x => tags.Any(t => x.Value.Contains(t))).Select(x => x.Key);
        }
    }
}
