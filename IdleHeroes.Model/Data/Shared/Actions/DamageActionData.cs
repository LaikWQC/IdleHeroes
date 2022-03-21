namespace IdleHeroes.Model
{
    public class DamageActionData : ActionData
    {
        public DamageActionData(string id, int potency) : base(id)
        {
            Potency = potency;
        }

        public int Potency { get; }
    }
}
