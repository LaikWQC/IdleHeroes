using LaikWQC.Utils.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class Perk
    {
        private readonly JobModel _owner;
        public readonly PerkData _data;

        public Perk(JobModel owner, PerkData data)
        {
            _owner = owner;
            _data = data;

            CmdBuy = new MyCommand(Buy, CanBuy);

            if (_data.Price == null)
                Buy();
        }

        public IPerk Value => _data;
        public string Id => _data.Id;
        public int Price => _data.Price ?? 0;
        public bool IsBought { get; private set; } = false;

        public ICommand CmdBuy { get; }
        private bool CanBuy() => !IsBought && _owner.Experience >= Price;
        private void Buy() 
        {
            _owner.Experience -= Price;
            IsBought = true;
        }
    }
}
