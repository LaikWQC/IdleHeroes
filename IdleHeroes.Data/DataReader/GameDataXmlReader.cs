using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace IdleHeroes.Data
{
    public static class GameDataXmlReader
    {
        public static void ReadFromResources(IHeroDataBuilder builder)
        {
            Read(XDocument.Parse(GameResources.GameData), builder);
        }

        private static void Read(XDocument xDoc, IHeroDataBuilder builder)
        {
            var xJobs = xDoc.Root.Elements("Jobs").Elements("Job");
            foreach (var xJob in xJobs)
            {
                var jobBuilder = builder.CreateJob(xJob.ParseName());
                foreach(var xPerk in xJob.Element("Perks").Elements())
                {
                    switch(xPerk.Name.LocalName)
                    {
                        case "Ability":
                            AddAbility(xPerk, jobBuilder);
                            break;
                    }
                }
            }
        }

        private static void AddAbility(XElement xAbility, IJobDataBuilder builder)
        {
            var ability = new AbilityDto()
            {
                Id = xAbility.ParseId(),
                Name = xAbility.ParseName(),
                TargetType = xAbility.ParseToAbilityTargetType(),
                ChanceType = xAbility.ParseToChanceType(),
                Chance = xAbility.ParseToIntOrDefault("Chance")
            };
            var abilityBuilder = builder.AddAbility(ability);

            foreach (var xAction in xAbility.Elements())
            {
                switch (xAction.Name.LocalName)
                {
                    case "Damage":
                        abilityBuilder.AddDamage(xAction.ParseToIntOrDefault("Potency"));
                        break;
                    case "Effect":
                        AddEffect(xAction, abilityBuilder);
                        break;
                }
            }
        }

        private static void AddEffect(XElement xEffect, IAbilityDataBuilder builder)
        {
            var effect = new EffectDto()
            {
                TargetType = xEffect.ParseToEffectTargetType(),
                DurationType = xEffect.ParseToDurationType(),
                Duration = xEffect.ParseToIntOrDefault("Duration")
            };
            var effectBuilder = builder.AddEffect(effect);

            foreach (var xEffectAction in xEffect.Elements())
            {
                switch (xEffectAction.Name.LocalName)
                {
                    case "MinDamage":
                        effectBuilder.AddMinDamage(xEffectAction.ParseToIntOrDefault("Value"));
                        break;
                    case "DoT":
                        effectBuilder.AddDoT(xEffectAction.ParseToIntOrDefault("Potency"));
                        break;
                    case "IncomingDamage":
                        effectBuilder.AddIncomingDamage(xEffectAction.ParseToIntOrDefault("Value"));
                        break;
                }
            }
        }
    }
}
