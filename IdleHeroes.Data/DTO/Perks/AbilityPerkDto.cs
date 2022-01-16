namespace IdleHeroes.Data
{
    public class AbilityPerkDto : PerkDto
    {
        public string AbilityId { get; set; }

        public override void CreatePerk(IPerkBuilder builder)
        {
            builder.AddAbilityPerk(this);
        }
    }
}
