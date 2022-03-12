using IdleHeroes.Model;

namespace IdleHeroes.WPF.ViewModels
{
    public class RoomViewModel
    {
        private readonly HeroModel _hero;

        public RoomViewModel(HeroModel hero)
        {
            _hero = hero;
        }
    }
}
