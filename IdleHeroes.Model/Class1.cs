using IdleHeroes.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public class DataLoader
    {
        public void LoadData()
        {
            var errors = new DataErrorBase();
            var reader = new GameDataXmlReader(errors);
            reader.ReadFromResources();
            var doc = reader.Product;
            var context = doc.CreateDataContext(errors);

            var jobFactories = new List<JobDataFactory>();
            foreach(var job in doc.Jobs)
            {
                var perkFactories = new List<PerkPointFactory>();
                foreach(var perkPoint in job.PerkPoints)
                {
                    var perkBuilder = new PerkDataBuilder(context, errors);
                    perkPoint.Values.ForEach(x => x.Perk.CreatePerk(perkBuilder));
                    perkBuilder.Perks.Select(data=>new PerkValue())
                    perkFactories.Add(new PerkPointFactory(perkPoint.Id,perkPoint.Price, )
                }
                jobFactories.Add(new JobDataFactory(job.Name, job.Tags, perkFactories));
            }
            var heroFactory = new HeroDataFactory(jobFactories);

            var availableJobs = heroFactory.GetAvailableJobs();
            var hero = heroFactory.CreateHero(availableJobs.First());
        }
    }
}
