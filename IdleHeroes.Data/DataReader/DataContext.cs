using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class DataContext
    {
        public Dictionary<string, AbilityData> Abiities { get; } = new Dictionary<string, AbilityData>();
        public Dictionary<string, ActionData> Actions { get; } = new Dictionary<string, ActionData>();
    }
}
