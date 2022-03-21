namespace IdleHeroes.Model
{
    public class EffectActionData : ActionData
    {
        public EffectActionData(string id, EffectData effect) : base(id)
        {
            Effect = effect;
        }

        public EffectData Effect { get; }
    }
}
