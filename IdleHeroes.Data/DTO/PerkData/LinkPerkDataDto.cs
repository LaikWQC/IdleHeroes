namespace IdleHeroes.Data
{
    public class LinkPerkDataDto : PerkDataDto
    {
        public string AbilityId { get; set; }
        public string ActionId { get; set; }

        public override void CreatePerk(IPerkDataBuilder builder)
        {
            builder.AddLinkPerk(this);
        }
    }
}
