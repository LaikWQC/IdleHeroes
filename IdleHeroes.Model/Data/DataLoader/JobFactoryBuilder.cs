using IdleHeroes.Data;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class JobFactoryBuilder : IJobDataBuilder
        {
            private readonly string _name;
            private List<AbilityFactoryBuilder> _abilities = new List<AbilityFactoryBuilder>();

            public JobFactoryBuilder(string name)
            {
                _name = name;
            }

            public IAbilityDataBuilder AddAbility(AbilityDto ability)
            {
                var builder = new AbilityFactoryBuilder(ability);
                _abilities.Add(builder);
                return builder;
            }

            public JobFactory Create()
            {
                return new JobFactory(_name, _abilities.Select(x => x.Create()));
            }
        }
    }
}
