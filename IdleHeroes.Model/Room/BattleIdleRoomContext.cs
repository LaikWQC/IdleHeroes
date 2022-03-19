using LaikWQC.Utils.Commands;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleIdleRoomContext : IRoomContext
    {
        private readonly IBattleRoom _owner;
        private readonly HeroBattleContext _heroBattleContext;

        public BattleIdleRoomContext(IBattleRoom owner, HeroAvatar avatar, HeroBattleContext heroBattleContext) 
        {
            CmdMoveToLocation = new MyCommand(MoveToLocation);
            _owner = owner;
            Hero = avatar;
            _heroBattleContext = heroBattleContext;

            _heroBattleContext.State.Value = BattleContextStates.Safe;
        }

        public JobModel HeroJob => _owner.Hero.CurrentJob;

        public void Dispose() { }

        private void MoveToLocation()
        {
            _owner.EnterToCombat(Hero, _heroBattleContext);
        }
        public ICommand CmdMoveToLocation { get; }
        public HeroAvatar Hero { get; }
    }
}
