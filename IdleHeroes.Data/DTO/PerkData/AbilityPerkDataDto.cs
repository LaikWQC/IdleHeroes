namespace IdleHeroes.Data
{
    public class AbilityPerkDataDto : PerkDataDto
    {
        public string AbilityId { get; set; }

        public override void CreatePerk(IPerkDataBuilder builder)
        {
            builder.AddAbilityPerk(this);
        }
    }
}
