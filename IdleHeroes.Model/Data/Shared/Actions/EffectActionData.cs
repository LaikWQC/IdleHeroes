namespace IdleHeroes.Model
{
    public class EffectActionData : ActionData
    {
        private readonly string _effectId; //TODO заменить на ссылку на еффект

        public EffectActionData(string id, string buffId) : base(id)
        {
            _effectId = buffId;
        }

        public override void CreateAction(HeroStatistic statistic)
        {
            //TODO
        }
    }
}
