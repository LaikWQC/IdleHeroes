namespace IdleHeroes.Data
{
    public class DamageActionDto : ActionDto
    {
        public double Potency { get; set; }

        public override void CreateAction(IActionDataBuilder builder)
        {
            builder.AddAction(this);
        }
    }
}
