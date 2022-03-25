namespace IdleHeroes.Model
{
    public class IncomingDamageActionOfEffect : ActionOfEffectModel
    {
        public IncomingDamageActionOfEffect(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
