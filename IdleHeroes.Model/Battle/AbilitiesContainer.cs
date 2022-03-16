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
        }

        public AbilityModel GetAbility()
        {
            return _abilities.First();
        }
    }
}
