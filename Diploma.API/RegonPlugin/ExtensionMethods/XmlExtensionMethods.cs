// Ignore Spelling: Regon, Plugin, Deserialize, Zaloguj, Wyloguj, Szukaj
// Ignore Spelling: Nullable
using RegonPlugin.Exceptions;
using RegonPlugin.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RegonPlugin.ExtensionMethods
{
    internal static class XmlExtensionMethods
    {
        private static readonly XNamespace _namespace = ConfigureData.NAMESPACE;
        private static readonly XNamespace _namespaceGetValueResult = ConfigureData.NAMESPACE_GET_VALUE_RESULT;


        public static XElement GetZalogujResult(this XDocument document)
        {
            return document.GetElement(
                _namespace,
                ConfigureData.RESPONSE_ELEMENT_ZALOGUJ);
        }

        public static XElement GetWylogujResult(this XDocument document)
        {
            return document.GetElement(
                _namespace,
                ConfigureData.RESPONSE_ELEMENT_WYLOGUJ);
        }

        public static XElement GetValueResult(this XDocument document)
        {
            return document.GetElement(
                _namespaceGetValueResult,
                ConfigureData.RESPONSE_ELEMENT_GET_VALUE_RESULT);
        }

        public static IEnumerable<XElement> GetDane(this XDocument document)
        {
            return document.GetElements(
                _namespace,
                ConfigureData.RESPONSE_ELEMENT_DANE);
        }

        public static Optional<T> DeserializeToClass<T>(this XElement element)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(element.Value))
            {
                return Optional<T>.None();
            }

            var serializer = new XmlSerializer(typeof(T));
            using var reader = element.CreateReader();

            if (serializer.CanDeserialize(reader))
            {
                var value = serializer.Deserialize(reader) as T;
                if (value != null)
                {
                    return Optional<T>.Some(value);
                }
            }

            throw new RegonDeserializationException($"Class Type: {nameof(T)}; Element Name: {element.Name}; Value: {element.Value};");
        }

        public static Optional<TEnum> DeserializeToEnum<TEnum>(this XElement element)
            where TEnum : Enum
        {
            if (string.IsNullOrWhiteSpace(element.Value))
            {
                return Optional<TEnum>.None();
            }

            if (int.TryParse(element.Value, out var enumId))
            {
                var value = (TEnum)Enum.ToObject(typeof(TEnum), enumId);
                return Optional<TEnum>.Some(value);
            }

            throw new RegonDeserializationException($"Enum Type: {nameof(TEnum)}; Element Name: {element.Name}; Value: {element.Value};");
        }

        // Private Methods
        private static XElement GetElement(
            this XDocument document,
            XNamespace @namespace,
            string elementName)
        {
            return GetElements(document, @namespace, elementName)
                .FirstOrDefault()
               ?? throw new RegonDeserializationException($"Element: {elementName}; Namespace: {@namespace}; Document: {document};");
        }

        private static IEnumerable<XElement> GetElements(
            this XDocument document,
            XNamespace @namespace,
            string elementName)
        {
            return document.Descendants(@namespace + elementName);
        }
    }
}
