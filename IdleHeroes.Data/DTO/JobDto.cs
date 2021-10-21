using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class JobDto
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public List<PerkPointDto> PerkPoints { get; } = new List<PerkPointDto>();
    }
}
