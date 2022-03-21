using IdleHeroes.Data;

namespace IdleHeroes.Model
{
    public class DoTEffectData : EffectAction
    {
        public DoTEffectData (int potency)
        {
            Potency = potency;
        }

        public int Potency { get; }
    }
}
