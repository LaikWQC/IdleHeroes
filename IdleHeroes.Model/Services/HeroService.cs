using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdleHeroes.Model.Services
{
    public class HeroService : Singletone<HeroService>
    {
        private HeroFactory _heroFactory;
        private List<HeroModel> _heroes = new List<HeroModel>();
        
        public void Initialize(HeroFactory heroFactory)
        {
            _heroFactory = heroFactory;
        }

        public HeroModel CreateHero()
        {
            var job = _heroFactory.GetAvailableJobs().First();
            var hero = _heroFactory.CreateHero(job);
            _heroes.Add(hero);
            NewHeroAdded?.Invoke(hero);
            return hero;
        }

        public event Action<HeroModel> NewHeroAdded;
    }
}
