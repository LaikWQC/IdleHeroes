namespace IdleHeroes.Data
{
    public abstract class EffectDto
    {
        public string Id { get; set; }
        public int Duration { get; set; }
        public EffectTargetTypes TargetType {get;set;}
        public abstract void CreateEffect(IEffectDataBuilder builder);
    }
}
