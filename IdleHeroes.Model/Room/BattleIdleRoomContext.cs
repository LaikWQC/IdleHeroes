using LaikWQC.Utils.Commands;
using System.Windows.Input;

namespace IdleHeroes.Model
{
    public class BattleIdleRoomContext : IRoomContext
    {
        private readonly IBattleRoom _owner;

        public BattleIdleRoomContext(IBattleRoom owner) 
        {
            CmdMoveToLocation = new MyCommand(MoveToLocation);
            _owner = owner;
        }

        public void Dispose() { }

        private void MoveToLocation()
        {
            _owner.EnterToCombat();
        }
        public ICommand CmdMoveToLocation { get; }
    }
}
