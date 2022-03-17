using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class HeroAvatar : Avatar
    {
        private IHeroBattleContext _context;

        public HeroAvatar(AvatarDto dto, AbilitiesContainer container, IHeroBattleContext context) : base(dto, container, context)
        {
            _context = context;

            OnUpdate = DoNothing;
            _context.StateChanged += OnStateChanged;
            _context.State = BattleContextStates.Hunting;
        }

        protected override void Update(double deltaTime) 
        {
            OnUpdate?.Invoke(deltaTime);
        }
        protected Action<double> OnUpdate;

        private void OnStateChanged()
        {
            switch (_context.State)
            {
                case BattleContextStates.Idle:
                    _context.State = BattleContextStates.Hunting;
                    break;
                case BattleContextStates.Hunting:
                    RemoveAbility();
                    OnUpdate = DoNothing;
                    break;
                case BattleContextStates.Battle:
                    ChooseAbility();
                    OnUpdate = Battle;
                    break;
            }
        }
    }
}
