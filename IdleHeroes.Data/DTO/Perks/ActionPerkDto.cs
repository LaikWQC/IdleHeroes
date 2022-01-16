namespace IdleHeroes.Data
{
    public class ActionPerkDto : PerkDto
    {
        public string ActionId { get; set; }

        public override void CreatePerk(IPerkBuilder builder)
        {
            builder.AddActionPerk(this);
        }
    }
}
