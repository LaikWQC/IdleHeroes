namespace IdleHeroes.Data
{
    public class ActionPerkDataDto : PerkDataDto
    {
        public string ActionId { get; set; }

        public override void CreatePerk(IPerkDataBuilder builder)
        {
            builder.AddActionPerk(this);
        }
    }
}
