namespace IdleHeroes.Model
{
    public abstract class ActionData
    {
        public ActionData(string id, string abilityId)
        {
            Id = id;
            AbilityId = abilityId;
        }

        public string Id { get; }
        public string AbilityId { get; }

        public abstract void AddAction(HeroAvatarBuilder hero);
    }
}
