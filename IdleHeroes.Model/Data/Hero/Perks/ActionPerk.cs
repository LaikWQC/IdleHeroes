namespace IdleHeroes.Model
{
    public class ActionPerk : Perk
    {
        private readonly ActionData _action;

        public ActionPerk(ActionData action)
        {
            _action = action;
        }

        public override void Apply(HeroAvatarBuilder statistic)
        {
            _action.CreateAction(statistic);
        }
    }
}
