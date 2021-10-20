namespace IdleHeroes.Data
{
    public class BuffActionData : ActionData
    {
        private readonly string _buffId; //TODO заменить на ссылку на баф

        public BuffActionData(string id, string buffId) : base(id)
        {
            _buffId = buffId;
        }
    }
}
