using IdleHeroes.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace IdleHeroes.Model
{
    public class AbilityModel
    {
        private List<ActionModel> _actions;
        private AbilityTargetTypes _targetType;

        public AbilityModel(string name, AbilityTargetTypes targetType, ChanceTypes chanceType, int chance, IEnumerable<ActionModel> actions)
        {
            Name = name;
            _targetType = targetType;
            ChanceType = chanceType;
            Chance = chance;
            _actions = actions.ToList();
        }

        public string Name { get; }
        public ChanceTypes ChanceType { get; }
        public int Chance { get; }


        public void UseAbility(IBattleContext context, CancellationToken token)
        {
            foreach(var action in _actions)
            {
                if (token.IsCancellationRequested) return;
                action.UseAction(context); //TODO set target by type
            }
        }
    }
}
