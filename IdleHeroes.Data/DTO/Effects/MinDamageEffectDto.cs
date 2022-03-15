namespace IdleHeroes.Data
{
    public class MinDamageEffectDto : EffectDto
    {
        public int Value { get; set; }

        public override void CreateEffect(IEffectDataBuilder builder)
        {
            builder.AddEffect(this);
        }
    }
}
