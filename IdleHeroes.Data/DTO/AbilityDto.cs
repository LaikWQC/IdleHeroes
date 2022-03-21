namespace IdleHeroes.Data
{
    public class AbilityDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AbilityTargetTypes TargetType { get; set; }
        public ChanceTypes ChanceType { get; set; }
        public int Chance { get; set; }
    }
}
