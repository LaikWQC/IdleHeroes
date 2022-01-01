namespace IdleHeroes.Data
{
    public class DamageActionData : ActionData
    {
        private readonly double _potency;

        public DamageActionData(string id, double potency) : base(id)
        {
            _potency = potency;
        }
    }
}
