using IdleHeroes.Model;
using IdleHeroes.Model.Services;
using System;
using System.Collections.ObjectModel;

namespace IdleHeroes.WPF.ViewModel
{
    public class HeroesTabViewModel
    {
        public HeroesTabViewModel()
        {
            HeroService.Instance.NewHeroAdded += OnHeroAdded;
        }

        public ObservableCollection<RoomModel> Rooms { get; } = new ObservableCollection<RoomModel>();

        private void OnHeroAdded(HeroModel hero)
        {
            Rooms.Add(new RoomModel(hero));
        }
    }
}
