namespace IdleHeroes.Model
{
    public class EffectActionData : ActionData
    {
        private readonly EffectData _effect;

        public EffectActionData(string id, EffectData effect) : base(id)
        {
            _effect = effect;
        }

        public override void CreateAction(HeroStatistic statistic)
        {
            var factory = _effect.EnsureCreateEffectFactory(statistic);
            statistic.Actions[_id] = new EffectActionModel.Builder(factory); 
        }
    }
}
