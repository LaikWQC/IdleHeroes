using IdleHeroes.Data;
using IdleHeroes.Model;
using IdleHeroes.Model.Services;
using IdleHeroes.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace IdleHeroes.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            HeroDataLoader.LoadData(new DataErrorBase());

            new MainWindow() { DataContext = new MainViewModel() }.Show();
        }
    }
}
