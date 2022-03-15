namespace IdleHeroes.Data
{
    public class DoTEffectDto : EffectDto
    {
        public int Potency { get; set; }

        public override void CreateEffect(IEffectDataBuilder builder)
        {
            builder.AddEffect(this);
        }
    }
}
