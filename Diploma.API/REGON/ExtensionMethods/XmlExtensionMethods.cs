// Ignore Spelling: Deserialize, REGON, Zaloguj, Wyloguj
using REGON.Exceptions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace REGON.ExtensionMethods
{
    internal static class XmlExtensionMethods
    {
        // Fields
        private const string ZALOGUJ_RESULT = "ZalogujResult";
        private const string WYLOGUJ_RESULT = "WylogujResult";
        private const string GET_VALUE_RESULT = "GetValueResult";
        private const string ROOT = "root";

        private static readonly XNamespace _namespace = "http://CIS/BIR/PUBL/2014/07";
        private static readonly XNamespace _namespaceGetValueResult = "http://CIS/BIR/2014/07";


        // Methods
        public static XElement GetZalogujResult(this XDocument document)
        {
            return document.GetElement(_namespace, ZALOGUJ_RESULT);
        }

        public static XElement GetWylogujResult(this XDocument document)
        {
            return document.GetElement(_namespace, WYLOGUJ_RESULT);
        }

        public static XElement GetValueResult(this XDocument document)
        {
            return document.GetElement(_namespaceGetValueResult, GET_VALUE_RESULT);
        }

        public static XElement? GetRoot(this XDocument document)
        {
            return document
                .Descendants(_namespace + ROOT)
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

        // Private Methods
        private static XElement GetElement(
            this XDocument document,
            XNamespace @namespace,
            string elementName)
        {
            return document
               .Descendants(@namespace + elementName)
               .FirstOrDefault()
               ?? throw new RegonException();
        }
    }
}
