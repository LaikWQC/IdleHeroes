using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdleHeroes.Model
{
    public interface IAbilityBuilder 
    {
        void AddAction(ActionModel action);
        AbilityModel Product { get; }
    }

    public class AbilityModel
    {
        private AbilityModel() 
        {
            Actions = new ReadOnlyCollection<ActionModel>(_actions);
        }

        public int CooldownMulti { get; private set; }
        private List<ActionModel> _actions;
        public IReadOnlyCollection<ActionModel> Actions { get; }

        public class Builder : IAbilityBuilder
        {
            public Builder(int cooldownMulti)
            {
                Product = new AbilityModel();
                Product.CooldownMulti = cooldownMulti;
            }

            public void AddAction(ActionModel action)
            {
                Product._actions.Add(action);
            }

            public AbilityModel Product { get; }
        }
    }
}
