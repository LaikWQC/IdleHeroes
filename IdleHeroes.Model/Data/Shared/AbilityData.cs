using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class AbilityData
    {
        public AbilityData(AbilityDto dto, IEnumerable<ActionData> actions)
        {
            Id = dto.Id;
            Name = dto.Name;
            TargetType = dto.TargetType;
            ChanceType = dto.ChanceType;
            Chance = dto.Chance;

            Actions = actions.ToList().AsReadOnly();
        }

        public string Id { get; }
        public string Name { get; }
        public AbilityTargetTypes TargetType { get; }
        public ChanceTypes ChanceType { get; }
        public int Chance { get; }
        public ICollection<ActionData> Actions { get; }

        public void AddAbility(HeroAvatarBuilder hero)
        {
            hero.Abilities.Add(Id, new AbilityBuilder(this));
            foreach(var action in Actions)
                action.AddAction(hero);
        }
    }
}
