using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class DataDocument
    {
        public List<JobDto> Jobs { get; } = new List<JobDto>();
        public List<AbilityDto> Abilities { get; } = new List<AbilityDto>();
        public List<ActionDto> Actions { get; } = new List<ActionDto>();
    }
}
