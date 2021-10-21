using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class PerkPointDto
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public List<PerkValueDto> Values { get; } = new List<PerkValueDto>();
    }
}
