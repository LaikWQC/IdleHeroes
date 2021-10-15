﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdleHeroes.Data
{
    public class PerkPointFactory
    {
        private readonly int _price;
        private readonly List<PerkValue> _values;

        public PerkPointFactory(int price, IEnumerable<PerkValue> values)
        {
            _price = price;
            _values = values.ToList();
        }

        public PerkPoint CreatePerk(JobData job, PerksCollector collector)
        {
            return new PerkPoint(job, collector, _price, _values);
        }
    }
}
