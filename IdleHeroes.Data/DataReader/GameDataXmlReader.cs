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
                    var perk = new PerkDto()
                    {
                        Id = xPerk.ParseId(),
                        ShareType = xPerk.ParseToShareType(),
                        Price = xPerk.ParseToInt("Price")
                    };
                    switch (xPerk.Name.LocalName)
                    {
                        case "Ability":
                            AddAbility(perk, xPerk, jobBuilder);
                            break;
                    }
                }
            }
        }

        private static void AddAbility(PerkDto perk, XElement xAbility, IJobDataBuilder builder)
        {
            var ability = new AbilityDto()
            {
                Id = perk.Id,
                Name = xAbility.ParseName(),
                TargetType = xAbility.ParseToAbilityTargetType(),
                ChanceType = xAbility.ParseToChanceType(),
                Chance = xAbility.ParseToIntOrDefault("Chance")
            };
            var abilityBuilder = builder.AddAbilityPerk(perk, ability);

            foreach (var xAction in xAbility.Elements())
            {
                var id = xAction.ParseId() ?? ability.Id;
                switch (xAction.Name.LocalName)
                {
                    case "Damage":
                        abilityBuilder.AddDamage(id, xAction.ParseToIntOrDefault("Potency"));
                        break;
                    case "Effect":
                        AddEffect(id, xAction, abilityBuilder);
                        break;
                }
            }
        }

        private static void AddEffect(string id, XElement xEffect, IAbilityDataBuilder builder)
        {
            var effect = new EffectDto()
            {
                Id = id,
                TargetType = xEffect.ParseToEffectTargetType(),
                DurationType = xEffect.ParseToDurationType(),
                Duration = xEffect.ParseToIntOrDefault("Duration")
            };
            var effectBuilder = builder.AddEffect(effect);

            foreach (var xEffectAction in xEffect.Elements())
            {
                var actionId = xEffectAction.ParseId() ?? id;
                switch (xEffectAction.Name.LocalName)
                {
                    case "MinDamage":
                        effectBuilder.AddMinDamage(actionId, xEffectAction.ParseToIntOrDefault("Value"));
                        break;
                    case "DoT":
                        effectBuilder.AddDoT(actionId, xEffectAction.ParseToIntOrDefault("Potency"));
                        break;
                    case "IncomingDamage":
                        effectBuilder.AddIncomingDamage(actionId, xEffectAction.ParseToIntOrDefault("Value"));
                        break;
                }
            }
        }
    }
}
