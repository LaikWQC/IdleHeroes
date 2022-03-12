using IdleHeroes.Model;
using IdleHeroes.Model.Services;

namespace IdleHeroes.Model
{
    public class RoomModel : IBattleRoom
    {
        public RoomModel(HeroModel hero)
        {
            RoomContext = PropertyService.Instance.CreateProperty<IRoomContext>();
            Hero = hero;
            EnterToIdle();
        }
        public HeroModel Hero { get; }

        public IProperty<IRoomContext> RoomContext { get; }

        public void EnterToIdle()
        {
            RoomContext.Value?.Dispose();
            RoomContext.Value = new BattleIdleRoomContext(this);
        }
        public void EnterToCombat()
        {
            RoomContext.Value?.Dispose();
            RoomContext.Value = new BattleCombatRoomContext(this);
        }
    }
    public interface IBattleRoom
    {
        void EnterToIdle();
        void EnterToCombat();
        HeroModel Hero { get; }
    }
}
