using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdleHeroes.Model
{
    public class PerkFactory
    {
        private readonly PerkData _perk;

        public PerkFactory(PerkData perk)
        {
            _perk = perk;
        }

        public Perk CreatePerk(JobModel job)
        {
            return new Perk(job, _perk);
        }
    }
}
