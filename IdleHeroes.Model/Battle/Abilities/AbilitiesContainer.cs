using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class AbilitiesContainer
    {
        private readonly List<AbilityModel> _abilities;
        private List<(AbilityModel Ability, double Chance)> _abilitiesChance = new List<(AbilityModel Ability, double Chance)>();
        private Random _random;

        public AbilitiesContainer(IEnumerable<AbilityModel> abilities)
        {
            _abilities = abilities.ToList();
            _random = new Random();
            
            CalculateChances();
        }

        public AbilityModel GetAbility()
        {
            var value = _random.NextDouble() * 100;
            var combinedChance = 0D;
            foreach(var ability in _abilitiesChance)
            {
                combinedChance += ability.Chance;
                if (combinedChance >= value)
                    return ability.Ability;
            }
            return _abilitiesChance.LastOrDefault().Ability;
        }

        private void CalculateChances()
        {
            _abilitiesChance.Clear();
            var withChance = _abilities.Where(x => x.Chance.HasValue).ToList();
            var combinedChance = withChance.Sum(x => x.Chance.Value);
            var chanceMulti = combinedChance > 100 ? 100D / combinedChance : 1;
            foreach(var ability in withChance)
                _abilitiesChance.Add((ability, ability.Chance.Value * chanceMulti));
            if(combinedChance<100)
            {
                var restChance = 100 - combinedChance;
                var withNoChance = _abilities.Where(x => !x.Chance.HasValue).ToList();
                if(withNoChance.Count==0)
                    _abilitiesChance.Add((AbilityModel.CreateEmpty(), restChance));
                else
                {
                    var sharedChance = 1d * restChance / withNoChance.Count;
                    foreach (var ability in withNoChance)
                        _abilitiesChance.Add((ability, sharedChance));
                }
            }

            UpdateAbilitiesInfo();
        }

        private void UpdateAbilitiesInfo()
        {
            Maximum = Round(_abilitiesChance.Max(x => x.Chance));
            Abilities.AddRange(_abilitiesChance.OrderByDescending(x=>x.Chance).Select(x => 
            new AbilityInfo() { Percentage = Round(x.Chance), Name = x.Ability?.Name}));            
        }
        private int Round(double value) => (int)Math.Round(value);

        public List<AbilityInfo> Abilities { get; } = new List<AbilityInfo>();
        public int Maximum { get; set; }
    }
}
