namespace IdleHeroes.Model
{
    public class EffectActionData : ActionData
    {
        private readonly string _buffId; //TODO заменить на ссылку на баф

        public EffectActionData(string id, string buffId) : base(id)
        {
            _buffId = buffId;
        }
    }
}
