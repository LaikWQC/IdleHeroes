using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace IdleHeroes.Data
{
    public class GameDataXmlDirector
    {
        private readonly IGameDataBuilder _builder;

        public GameDataXmlDirector(IGameDataBuilder builder)
        {
            _builder = builder;
        }

        public void ReadFromResources()
        {
            Compute(XDocument.Parse(GameResources.GameData));
        }

        private void Compute(XDocument xDoc)
        {
            var doc = new DataDocument();
            var xJobs = xDoc.Root.Elements("Jobs").Elements("Job").ToList();
            foreach(var xJob in xJobs)
            {
                var jobDto = new JobDto()
                {
                    Name = xJob.ParseName(),
                    Tags = xJob.ParseTags().ToList()
                };
                var xSharedPerks = xJob.Elements("SharedPerks").Elements().ToList();
                var sharedPerks = xSharedPerks.ToDictionary(x => x.ParseToString("SharedId"), x => CreatePerkData(x));
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
            }
            return null; //TODO
        }
    }

    public static class XmlEx
    {
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
            return attribute.ToString();
        }

        public static IEnumerable<string> ParseToStringsCollection(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToStringsCollection();
        }
        public static IEnumerable<string> ParseToStringsCollection(this XAttribute attribute)
        {
            return attribute.ToString().Split(",", System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
