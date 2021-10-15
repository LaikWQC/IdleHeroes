using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Data
{
    public class PerksCollector
    {
        private Dictionary<PerkData, HashSet<string>> _perks = new Dictionary<PerkData, HashSet<string>>();

        public void AddPerk(PerkData perk, IEnumerable<string> newTags)
        {
            if (!_perks.TryGetValue(perk, out var tags))
                tags = _perks[perk] = new HashSet<string>();
            foreach (var tag in newTags)
                tags.Add(tag);
        }

        public IEnumerable<PerkData> GetPerks(ICollection<string> tags)
        {
            return _perks.Where(x => tags.Any(t => x.Value.Contains(t))).Select(x => x.Key);
        }
    }
}
