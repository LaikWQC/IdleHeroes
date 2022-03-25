namespace IdleHeroes.Model
{
    public class MinDamageActionOfEffect : ActionOfEffectModel
    {
        public MinDamageActionOfEffect(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
