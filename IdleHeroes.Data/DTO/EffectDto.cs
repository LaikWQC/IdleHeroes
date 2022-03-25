namespace IdleHeroes.Data
{
    public class EffectDto
    {
        public string Id { get; set; }
        public EffectTargetTypes TargetType { get; set; }
        public DurationTypes DurationType { get; set; }
        public int Duration { get; set; }
    }
}
