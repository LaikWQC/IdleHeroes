using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatar
    {
        private List<AbilityModel> _abilities;

        public HeroAvatar(IEnumerable<AbilityModel> abilities)
        {
            _abilities = abilities.ToList();
        }
    }
}
