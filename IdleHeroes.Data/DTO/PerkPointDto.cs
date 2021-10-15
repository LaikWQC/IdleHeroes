using System.Collections.Generic;

namespace IdleHeroes.Data
{
    public class PerkPointDto
    {
        public string Id { get; set; }
        public int Price { get; set; }
        List<PerkValueDto> Values { get; set; }
    }
}
