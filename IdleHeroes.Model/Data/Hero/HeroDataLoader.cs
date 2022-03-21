using IdleHeroes.Data;
using IdleHeroes.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdleHeroes.Model
{
    public static class HeroDataLoader
    {
        public static void LoadData(IDataError errors)
        {
            var reader = new GameDataXmlReader(errors);
            reader.ReadFromResources();
            var doc = reader.Product;
            var context = doc.CreateDataContext(errors);
            var perkConverter = new UniquePerkConverter(context, errors);

            var jobFactories = new List<JobFactory>();
            foreach(var job in doc.Jobs)
            {
                var perkFactories = new List<PerkPointFactory>();
                foreach(var perkPoint in job.Perks)
                    perkFactories.Add(new PerkPointFactory(perkPoint.Id, perkPoint.Price, perkPoint.Values.Select(x => new PerkValue(perkConverter.Convert(x.Perk), x.Tags))));
                jobFactories.Add(new JobFactory(job.Name, job.Tags, perkFactories));
            }
            var heroFactory = new HeroFactory(jobFactories);

            HeroService.Instance.Initialize(heroFactory);
        }
    }
}
