// Ignore Spelling: Deserialize, REGON, Zaloguj, Wyloguj
using System.Xml.Linq;
using System.Xml.Serialization;

namespace REGON.ExtensionMethods
{
    internal static class XmlExtensionMethods
    {
        // Properties
        private static readonly XNamespace _namespace = "http://CIS/BIR/PUBL/2014/07";
        private static readonly XNamespace _namespaceGetValueResult = "http://CIS/BIR/2014/07";


        // Methods
        /// <summary>
        /// </summary>
        /// <param name="document"></param>
        /// <returns>If correct UserKey element contains SessionId, if not empty element </returns>
        public static XElement? GetZalogujResult(this XDocument document)
        {
            return document
                .Descendants(_namespace + "ZalogujResult")
                .FirstOrDefault();
        }

        public static XElement? GetWylogujResult(this XDocument document)
        {
            return document
                .Descendants(_namespace + "WylogujResult")
                .FirstOrDefault();
        }

        public static XElement? GetValueResult(this XDocument document)
        {
            return document
                .Descendants(_namespaceGetValueResult + "GetValueResult")
                .FirstOrDefault();
        }

        public static XElement? GetRoot(this XDocument document)
        {
            return document
                .Descendants(_namespace + "root")
                .FirstOrDefault();
        }

        public static T DeserializeClass<T>(this XElement element)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = element.CreateReader())
            {
                return serializer.Deserialize(reader) as T
                    ?? throw new Exception();
            }
        }

        public static TEnum DeserializeEnum<TEnum>(this XElement element)
            where TEnum : Enum
        {
            if (string.IsNullOrWhiteSpace(element.Value) ||
                !int.TryParse(element.Value, out var enumId))
            {
                throw new NotImplementedException(element.Value);
            }
            return (TEnum)Enum.ToObject(typeof(TEnum), enumId);
        }
    }
}
