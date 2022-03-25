namespace IdleHeroes.Model
{
    public class EffectActionData : ActionData
    {
        public EffectActionData(string id, string abilityId, EffectData effect) : base(id, abilityId)
        {
            Effect = effect;
        }

        public EffectData Effect { get; }

        public override void AddAction(HeroAvatarBuilder hero)
        {
            if (!hero.Abilities.TryGetValue(AbilityId, out var ability)) return;

            var effectBuilder = new EffectFactoryBuilder(Effect);
            hero.Effects.Add(Effect.Id, effectBuilder);

            var actionBuilder = new EffectActionBuilder(Effect.TargetType, effectBuilder);
            ability.AddAction(actionBuilder);
            hero.Actions.Add(Id, actionBuilder);

            foreach (var action in Effect.Actions)
                action.AddAction(hero);
        }
    }
}
