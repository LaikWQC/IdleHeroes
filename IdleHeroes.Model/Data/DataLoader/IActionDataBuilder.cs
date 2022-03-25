namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private interface IActionDataBuilder
        {
            ActionData Create();
        }
    }
}
