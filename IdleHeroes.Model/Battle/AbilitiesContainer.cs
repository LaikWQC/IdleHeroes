using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class AbilitiesContainer
    {
        private readonly List<AbilityModel> _abilities;
        public AbilitiesContainer(IEnumerable<AbilityModel> abilities)
        {
            _abilities = abilities.ToList();
            Abilities = _abilities.Select(x => new AbilityInfo() { Percentage = 100 / _abilities.Count, Name = x.Name }).ToList();
            Maximum = Abilities.Max(x => x.Percentage);
        }

        public AbilityModel GetAbility()
        {
            return _abilities.First();
        }

        public List<AbilityInfo> Abilities { get; }
        public int Maximum { get; }
    }
}
