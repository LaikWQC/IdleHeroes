namespace IdleHeroes.Data
{
    public interface IActionDataBuilder
    {
        void AddAction(DamageActionDto action);
        void AddAction(EffectActionDto action);
    }
}
