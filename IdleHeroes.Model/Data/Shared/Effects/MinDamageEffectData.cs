using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class MinDamageEffectData : EffectAction
    {
        public MinDamageEffectData(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
