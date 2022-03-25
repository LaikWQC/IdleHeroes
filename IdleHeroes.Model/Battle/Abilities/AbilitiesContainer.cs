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
            var hight = _abilities.Where(x => x.ChanceType == Data.ChanceTypes.Hight).ToList();
            var hightChance = hight.Sum(x => x.Chance);
            if (hightChance >= 100) 
            {
                var chanceMulti = 100D / hightChance;
                foreach (var ability in hight)
                    _abilitiesChance.Add((ability, ability.Chance * chanceMulti));
            }
            else
            {
                foreach (var ability in hight)
                    _abilitiesChance.Add((ability, ability.Chance));

                var normal = _abilities.Where(x => x.ChanceType == Data.ChanceTypes.Normal).ToList();
                var combinedChance = normal.Sum(x => x.Chance) + hightChance;
                if (combinedChance >= 100)
                {
                    var restChance = 100 - combinedChance;
                    combinedChance = normal.Sum(x => x.Chance);
                    var chanceMulti = (double)restChance / hightChance;
                    foreach (var ability in normal)
                        _abilitiesChance.Add((ability, ability.Chance * chanceMulti));
                }
                else
                {
                    foreach (var ability in normal)
                        _abilitiesChance.Add((ability, ability.Chance));

                    var restChance = 100 - combinedChance;
                    var core = _abilities.Where(x => x.ChanceType == Data.ChanceTypes.Core).ToList();
                    if (core.Count == 0)
                        _abilitiesChance.Add((AbilityBuilder.CreateEmpty(), restChance));
                    else
                    {
                        var sharedChance = 1d * restChance / core.Count;
                        foreach (var ability in core)
                            _abilitiesChance.Add((ability, sharedChance));
                    }
                }
            }

            UpdateAbilitiesInfo();
        }

        private void UpdateAbilitiesInfo()
        {
            Maximum = Round(_abilitiesChance.Max(x => x.Chance));
            Abilities.AddRange(_abilitiesChance.OrderByDescending(x=>x.Chance).Select(x => 
            new AbilityInfo() { Percentage = Round(x.Chance), Name = x.Ability.Name}));            
        }
        private int Round(double value) => (int)Math.Round(value);

        public List<AbilityInfo> Abilities { get; } = new List<AbilityInfo>();
        public int Maximum { get; set; }
    }
}
