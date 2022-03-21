using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class IncomingDamageEffectData : EffectAction
    {
        public IncomingDamageEffectData(int value) 
        {
            Value = value;
        }

        public int Value { get; }
    }
}
