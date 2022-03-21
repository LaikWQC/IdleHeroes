using System;
using System.Xml.Linq;

namespace IdleHeroes.Data
{
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
        public static EffectTargetTypes ParseToEffectTargetType(this XElement element)
        {
            return element.ParseToEnum<EffectTargetTypes>("Target");
        }
        public static AbilityTargetTypes ParseToAbilityTargetType(this XElement element)
        {
            return element.ParseToEnum<AbilityTargetTypes>("Target");
        }
        public static ChanceTypes ParseToChanceType(this XElement element)
        {
            return element.ParseToEnum<ChanceTypes>("ChanceType");
        }
        public static DurationTypes ParseToDurationType(this XElement element)
        {
            return element.ParseToEnum<DurationTypes>("DurationType");
        }

        public static string ParseToString(this XElement element, string attribute)
        {
            return element.Attribute(attribute).ParseToString();
        }
        public static string ParseToString(this XAttribute attribute)
        {
            return attribute.Value.ToString();
        }

        //public static IEnumerable<string> ParseToStringsCollection(this XElement element, string attribute)
        //{
        //    return element.Attribute(attribute).ParseToStringsCollection();
        //}
        //public static IEnumerable<string> ParseToStringsCollection(this XAttribute attribute)
        //{
        //    return attribute.Value.ToString().Split(",", StringSplitOptions.RemoveEmptyEntries);
        //}

        public static int ParseToIntOrDefault(this XElement element, string attribute)
        {
            return element.ParseToInt(attribute) ?? 0;
        }
        public static int? ParseToInt(this XElement element, string attribute)
        {
            return element.Attribute(attribute)?.ParseToInt();
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

        public static T ParseToEnum<T>(this XElement element, string attribute) where T : struct
        {
            return element.Attribute(attribute).ParseToEnum<T>();
        }
        public static T ParseToEnum<T>(this XAttribute attribute) where T : struct
        {
            return attribute.Value.ToString().ParseToEnum<T>();
        }
        public static T ParseToEnum<T>(this string value) where T : struct
        {
            Enum.TryParse(value, out T result);
            return result;
        }
    }
}
