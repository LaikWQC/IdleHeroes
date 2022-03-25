namespace IdleHeroes.Model
{
    public class DamageActionData : ActionData
    {
        public DamageActionData(string id, string abilityId, int potency) : base(id, abilityId)
        {
            Potency = potency;
        }

        public int Potency { get; }

        public override void AddAction(HeroAvatarBuilder hero)
        {
            if (!hero.Abilities.TryGetValue(AbilityId, out var ability)) return;

            var builder = new DamageActionBuilder(Potency);
            ability.AddAction(builder);
            hero.Actions.Add(Id, builder);
        }
    }
}
