using IdleHeroes.Model.Services;

namespace IdleHeroes.Model
{
    public class HeroBattleContext : IHeroBattleContext
    {
        public HeroBattleContext()
        {
            State = PropertyService.Instance.CreateProperty(BattleContextStates.Idle);
        }

        public ITarget Self { get; set; }
        public ITarget Enemy { get; set; }
        public IProperty<BattleContextStates> State { get; }
    }
}
