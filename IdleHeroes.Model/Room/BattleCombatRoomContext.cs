using LaikWQC.Utils.Commands;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleCombatRoomContext : IRoomContext
    {
        private readonly IBattleRoom _owner;

        public BattleCombatRoomContext(IBattleRoom owner)
        {
            CmdMoveBack = new MyCommand(MoveBack);
            _owner = owner;
            Hero = _owner.Hero.CreateAvatar();
        }

        public void Dispose()
        {
            //TODO
        }

        private void MoveBack()
        {
            _owner.EnterToIdle();
        }
        public ICommand CmdMoveBack { get; }

        public HeroAvatar Hero { get; }
    }
}
