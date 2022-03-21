namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        private class DamageActionDataBuilder : IActionDataBuilder
        {
            private readonly ActionData _action;

            public DamageActionDataBuilder(string id, int potency)
            {
                _action = new DamageActionData(id, potency);
            }

            public ActionData Create() => _action;
        }
    }
}
