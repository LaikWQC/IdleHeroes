using System;
using System.Collections.Generic;
using System.Text;

namespace IdleHeroes.Data
{
    public interface IPerkDataBuilder
    {
        void AddAbilityPerk(AbilityPerkDataDto perk);
        void AddActionPerk(ActionPerkDataDto perk);
        void AddLinkPerk(LinkPerkDataDto perk);
    }
}
