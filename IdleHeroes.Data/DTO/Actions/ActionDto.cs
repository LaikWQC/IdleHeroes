namespace IdleHeroes.Data
{
    public abstract class ActionDto
    {
        public string Id { get; set; }
        public abstract void CreateAction(IActionDataBuilder builder);
    }
}
