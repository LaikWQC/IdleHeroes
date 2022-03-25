namespace IdleHeroes.Model
{
    public class DoTActionOfEffect : ActionOfEffectModel
    {
        public DoTActionOfEffect(int potency)
        {
            Potency = potency;
        }

        public int Potency { get; }
    }
}
