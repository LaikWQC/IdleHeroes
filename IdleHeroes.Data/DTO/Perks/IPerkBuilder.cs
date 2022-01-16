using System;
using System.Collections.Generic;
using System.Text;

namespace IdleHeroes.Data
{
    public interface IPerkBuilder
    {
        void AddAbilityPerk(AbilityPerkDto perk);
        void AddActionPerk(ActionPerkDto perk);
        void AddLinkPerk(LinkPerkDto perk);
    }
}
