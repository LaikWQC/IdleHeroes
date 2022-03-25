using IdleHeroes.Data;
using IdleHeroes.Model.Services;
using System;

namespace IdleHeroes.Model
{
    public static partial class HeroDataLoader
    {
        public static void LoadData()
        {
            var builder = new HeroFactoryBuilder();
            GameDataXmlReader.ReadFromResources(builder);
            HeroService.Instance.Initialize(builder.Create());
        }
    }
}
