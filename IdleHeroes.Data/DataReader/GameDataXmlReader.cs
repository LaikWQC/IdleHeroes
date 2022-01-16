using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace IdleHeroes.Data
{
    public class GameDataXmlReader
    {
        private readonly IDataError _error;
        public DataDocument Product { get; private set; }

        public GameDataXmlReader(IDataError error)
        {
            _error = error;
        }

        public void ReadFromResources()
        {
            Read(XDocument.Parse(GameResources.GameData));
        }

        private void Read(XDocument xDoc)
        {
            Product = new DataDocument();

            var xJobs = xDoc.Root.Elements("Jobs").Elements("Job").ToList();
            foreach(var xJob in xJobs)
            {
                var job = new JobDto()
                {
                    Name = xJob.ParseName(),
                    Tags = xJob.ParseTags().ToList()
                };
                Product.Jobs.Add(job);

                var xSharedPerks = xJob.Elements("SharedPerks").Elements().ToList();
                var sharedPerks = new Dictionary<string, PerkDataDto>();
                foreach(var xSharedPerk in xSharedPerks)
                {
                    var id = xSharedPerk.ParseToString("SharedId");
                    if (sharedPerks.ContainsKey(id))
                        _error.RepeatedSharedPerkIdError(id);
                    else
                        sharedPerks.Add(id, CreatePerkData(xSharedPerk));
                }
                
                var xPerkPoints = xJob.Elements("Perks").Elements().ToList();
                foreach(var xPerkPoint in xPerkPoints)
                {
                    var perkPoint = new PerkPointDto()
                    {
                        Id = xPerkPoint.ParseId(),
                        Price = xPerkPoint.ParseToInt("Price")
                    };
                    job.PerkPoints.Add(perkPoint);

                    var xPerks = xPerkPoint.Elements().ToList();
                    xPerks.ForEach(x => perkPoint.Values.Add(CreatePerkValue(x, sharedPerks)));
                }
            }

            var xAbilities = xDoc.Root.Elements("Abilities").Elements("Ability").ToList();
            foreach(var xAbility in xAbilities)
            {
                Product.Abilities.Add(new AbilityDto()
                {
                    Id = xAbility.ParseId(),
                    Name = xAbility.ParseName(),
                    CooldownMulti = xAbility.ParseToInt("Cd")
                });
            }

            var xActions = xDoc.Root.Elements("Actions").Elements().ToList();
            foreach(var xAction in xActions)
            {
                switch(xAction.Name.LocalName)
                {
                    case "Damage":
                        Product.Actions.Add(new DamageActionDto()
                        {
                            Id = xAction.ParseId(),
                            Potency = xAction.ParseToInt("Potency")
                        });
                        break;
                    case "Effect":
                        Product.Actions.Add(new EffectActionDto()
                        {
                            Id = xAction.ParseId(),
                            EffectId = xAction.ParseToString("EffectId")
                        });
                        break;
                    default:
                        _error.IncorrectActionTypeError(xAction.Name.LocalName);
                        break;
                }
            }
        }

        private PerkDataDto CreatePerkData(XElement xPerk)
        {
            switch(xPerk.Name.LocalName)
            {
                case "Ability":
                    return new AbilityPerkDataDto() { AbilityId = xPerk.ParseToString("AbilityId") };
                case "Action":
                    return new ActionPerkDataDto() { ActionId = xPerk.ParseToString("ActionId") };
                case "Link":
                    return new LinkPerkDataDto() 
                    { 
                        ActionId = xPerk.ParseToString("ActionId"), 
                        AbilityId = xPerk.ParseToString("AbilityId") 
                    };
                default:
                    _error.IncorrectPerkTypeError(xPerk.Name.LocalName);
                    return new NoPerkDto();
            }
        }

        private PerkValueDto CreatePerkValue(XElement xPerk, Dictionary<string,PerkDataDto> sharedPerks)
        {
            var value = new PerkValueDto() { Tags = xPerk.ParseTags().ToList() };
            switch (xPerk.Name.LocalName)
            {
                case "Shared":
                    var id = xPerk.ParseId();
                    if (sharedPerks.TryGetValue(id, out var perk))
                        value.Perk = perk;
                    else
                    {
                        _error.NoSharedPerkError(id);
                        value.Perk = new NoPerkDto();
                    }
                    break;
                default: 
                    value.Perk = CreatePerkData(xPerk);
                    break;
            }
            return value;
        }
    }

    public static class XmlDataEx
    {
        public static string ParseId(this XElement element)
        {
            return element.ParseToString("Id");
        }
        public static string ParseName(this XElement element)
        {
            return element.ParseToString("Name");
        }
        public static IEnumerable<string> ParseTags(this XElement element)
        {
            return element.ParseToStringsCollection("Tags");
        }

        public static string ParseToString(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToString();
        }
        public static string ParseToString(this XAttribute attribute)
        {
            return attribute.Value.ToString();
        }

        public static IEnumerable<string> ParseToStringsCollection(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToStringsCollection();
        }
        public static IEnumerable<string> ParseToStringsCollection(this XAttribute attribute)
        {
            return attribute.Value.ToString().Split(",", System.StringSplitOptions.RemoveEmptyEntries);
        }

        public static int ParseToInt(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToInt();
        }
        public static int ParseToInt(this XAttribute attribute)
        {
            return int.Parse(attribute.Value.ToString());
        }

        public static double ParseToDouble(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToDouble();
        }
        public static double ParseToDouble(this XAttribute attribute)
        {
            return double.Parse(attribute.Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
