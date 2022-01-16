namespace IdleHeroes.Data
{
    public class LinkPerkDto : PerkDto
    {
        public string AbilityId { get; set; }
        public string ActionId { get; set; }

        public override void CreatePerk(IPerkBuilder builder)
        {
            builder.AddLinkPerk(this);
        }
    }
}
