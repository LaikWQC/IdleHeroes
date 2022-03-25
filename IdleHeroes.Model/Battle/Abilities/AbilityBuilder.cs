using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class AbilityBuilder : IAbilityBuilder
    {
        private string _name;
        private AbilityTargetTypes _targetType;
        private List<IActionBuilder> _actions = new List<IActionBuilder>();
        public AbilityBuilder(AbilityData data)
        {
            _name = data.Name;
            _targetType = data.TargetType;
            ChanceType = data.ChanceType;
            Chance = data.Chance;
        }

        public void AddAction(IActionBuilder action)
        {
            _actions.Add(action);
        }

        public ChanceTypes ChanceType { get; set; }
        public int Chance { get; set; }

        public AbilityModel Create(HeroAvatarBuilder hero)
        {
            return new AbilityModel(_name, _targetType, ChanceType, Chance, _actions.Select(x => x.Create(hero)));
        }

        public static AbilityModel CreateEmpty(string name = "Miss")
            => new AbilityModel(name, AbilityTargetTypes.Enemy, ChanceTypes.Core, 100, new ActionModel[0]);
    }
}
