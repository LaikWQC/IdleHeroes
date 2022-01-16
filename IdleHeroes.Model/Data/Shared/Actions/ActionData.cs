namespace IdleHeroes.Model
{
    public abstract class ActionData
    {
        public ActionData(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
