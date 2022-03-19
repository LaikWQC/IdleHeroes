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

            HandleHero();
        }
        public HeroModel Hero { get; }

        public IProperty<IRoomContext> RoomContext { get; }

        public void EnterToIdle(HeroAvatar avatar, HeroBattleContext context)
        {
            RoomContext.Value?.Dispose();
            RoomContext.Value = new BattleIdleRoomContext(this, avatar, context);
        }
        public void EnterToCombat(HeroAvatar avatar, HeroBattleContext context)
        {
            RoomContext.Value?.Dispose();
            RoomContext.Value = new BattleCombatRoomContext(this, avatar, context);
        }

        private void HandleHero()
        {
            var battleContext = new HeroBattleContext();
            var avatar = HeroAvatarBuilder.CreateAvatar(Hero, battleContext);

            EnterToIdle(avatar, battleContext);
        }
    }
    public interface IBattleRoom
    {
        void EnterToIdle(HeroAvatar avatar, HeroBattleContext context);
        void EnterToCombat(HeroAvatar avatar, HeroBattleContext context);
        HeroModel Hero { get; }
    }
}
