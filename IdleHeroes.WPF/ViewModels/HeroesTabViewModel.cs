using IdleHeroes.Model;
using IdleHeroes.Model.Services;
using System;
using System.Collections.ObjectModel;

namespace IdleHeroes.WPF.ViewModels
{
    public class HeroesTabViewModel
    {
        public HeroesTabViewModel()
        {
            HeroService.Instance.NewHeroAdded += OnHeroAdded;
        }

        public ObservableCollection<RoomViewModel> Rooms { get; } = new ObservableCollection<RoomViewModel>();

        private void OnHeroAdded(HeroModel hero)
        {
            Rooms.Add(new RoomViewModel(hero));
        }
    }
}
