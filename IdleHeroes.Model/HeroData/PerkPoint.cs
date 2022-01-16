﻿using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class PerkPoint
    {
        private readonly JobModel _owner;
        private readonly PerksCollector _collector;
        private List<PerkValue> _values;

        public PerkPoint(string id, JobModel owner, PerksCollector collector, int price, IEnumerable<PerkValue> values)
        {
            Id = id;
            _owner = owner;
            _collector = collector;

            Price = price;
            _values = values.ToList();

            if (Price == 0)
                Buy();
        }

        public string Id { get; }
        public int Price { get; }
        public bool IsBought { get; private set; } = false;

        public bool CanBuy() => !IsBought && _owner.Experience >= Price;
        public bool Buy() 
        {
            if (!CanBuy()) return false;

            _owner.Experience -= Price;
            foreach (var value in _values)
                _collector.AddPerk(value.Perk, value.Tags);
            IsBought = true;
            return true;
        }
    }
}