namespace IdleHeroes.Data
{
    public interface IActionDataBuilder
    {
        void AddDamageAction(DamageActionDto action);
        void AddBuffAction(BuffActionDto action);
    }
}
