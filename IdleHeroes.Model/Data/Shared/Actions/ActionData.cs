namespace IdleHeroes.Model
{
    public abstract class ActionData
    {
        protected readonly string _id;

        public ActionData(string id)
        {
            _id = id;
        }

        public abstract void CreateAction(HeroStatistic statistic);
    }
}
