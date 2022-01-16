namespace IdleHeroes.Data
{
    public class EffectActionDto : ActionDto
    {
        public string EffectId { get; set; }

        public override void CreateAction(IActionDataBuilder builder)
        {
            builder.AddAction(this);
        }
    }
}
