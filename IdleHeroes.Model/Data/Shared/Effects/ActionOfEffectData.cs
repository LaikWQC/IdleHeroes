namespace IdleHeroes.Model
{
    public abstract class ActionOfEffectData
    {
        public ActionOfEffectData(string id, string effectId)
        {
            Id = id;
            EffectId = effectId;
        }

        public string Id { get; }
        public string EffectId { get; }

        public abstract void AddAction(HeroAvatarBuilder hero);
    }
}
