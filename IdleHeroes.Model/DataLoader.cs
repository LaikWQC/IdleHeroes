using IdleHeroes.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static class DataLoader
    {
        public static void LoadData(IDataError errors)
        {
            var reader = new GameDataXmlReader(errors);
            reader.ReadFromResources();
            var doc = reader.Product;
            var context = doc.CreateDataContext(errors);
            var perkConverter = new PerkConverter(context, errors);

            var jobFactories = new List<JobDataFactory>();
            foreach(var job in doc.Jobs)
            {
                var perkFactories = new List<PerkPointFactory>();
                foreach(var perkPoint in job.PerkPoints)
                    perkFactories.Add(new PerkPointFactory(perkPoint.Id, perkPoint.Price, perkPoint.Values.Select(x => new PerkValue(perkConverter.Convert(x.Perk), x.Tags))));
                jobFactories.Add(new JobDataFactory(job.Name, job.Tags, perkFactories));
            }
            var heroFactory = new HeroDataFactory(jobFactories);

            var availableJobs = heroFactory.GetAvailableJobs();
            var hero = heroFactory.CreateHero(availableJobs.First());
        }
    }
}
