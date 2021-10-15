using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class ActionDataBuilder : IActionDataBuilder
    {
        public List<ActionData> Actions { get; } = new List<ActionData>();
    }
}
