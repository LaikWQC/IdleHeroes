using GalaSoft.MvvmLight.Command;
using IdleHeroes.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IdleHeroes.WPF.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CmdCreateNewHero = new RelayCommand(CreateNewHero);
        }

        public HeroesTabViewModel HeroesTab { get; } = new HeroesTabViewModel();
        public ICommand CmdCreateNewHero { get; }

        private void CreateNewHero()
        {
            HeroService.Instance.CreateHero();
        }
    }
}
