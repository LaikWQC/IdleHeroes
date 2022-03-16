using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdleHeroes.Model
{
    public interface IAbilityBuilder 
    {
        void AddAction(ActionModel action);
        AbilityModel Product { get; }
        void Finish();
    }

    public class AbilityModel
    {
        private AbilityModel(string name)
        {
            Name = name;
        }

        public int CooldownMulti { get; private set; }
        public string Name { get; }

        private List<ActionModel> _actions;
        public void UseAbility(IBattleContext context)
        {
            foreach(var action in _actions)
            {
                action.UseAction(context.Enemy); //TODO target by type
            }
        }

        public class Builder : IAbilityBuilder
        {
            private List<ActionModel> _actions = new List<ActionModel>();
            public Builder(string name, int cooldownMulti)
            {
                Product = new AbilityModel(name);
                Product.CooldownMulti = cooldownMulti;
            }

            public void AddAction(ActionModel action)
            {
                _actions.Add(action);
            }

            public AbilityModel Product { get; }

            public void Finish()
            {
                Product._actions = _actions; //TODO Order
            }
        }
    }
}
