namespace IdleHeroes.Data
{
    public class BuffActionDto : ActionDto
    {
        public string BuffId { get; set; }

        public override void CreateAction(IActionDataBuilder builder)
        {
            builder.AddBuffAction(this);
        }
    }
}
