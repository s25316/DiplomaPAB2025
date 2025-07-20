// Ignore Spelling: Regon, Plugin, Deserialize, Zaloguj, Wyloguj, Szukaj
// Ignore Spelling: Nullable
using RegonPlugin.Exceptions;
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

        public static XElement? GetRoot(this XDocument document)
        {
            return document.GetNullableElement(
                _namespace,
                ConfigureData.RESPONSE_ELEMENT_ROOT);
        }

        public static T? DeserializeToClass<T>(this XElement element)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(element.Value))
            {
                return default;
            }

            var serializer = new XmlSerializer(typeof(T));
            using var reader = element.CreateReader();

            if (serializer.CanDeserialize(reader))
            {
                return serializer.Deserialize(reader) as T;
            }

            throw new RegonDeserializationException($"Class Type: {nameof(T)}; Element Name: {element.Name}; Value: {element.Value};");
        }

        public static TEnum? DeserializeToEnum<TEnum>(this XElement element)
            where TEnum : Enum
        {
            if (string.IsNullOrWhiteSpace(element.Value))
            {
                return default;
            }

            if (int.TryParse(element.Value, out var enumId))
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), enumId);
            }

            throw new RegonDeserializationException($"Enum Type: {nameof(TEnum)}; Element Name: {element.Name}; Value: {element.Value};");
        }

        // Private Methods
        private static XElement GetElement(
            this XDocument document,
            XNamespace @namespace,
            string elementName)
        {
            return GetNullableElement(document, @namespace, elementName)
               ?? throw new RegonDeserializationException($"Element: {elementName}; Namespace: {@namespace}; Document: {document};");
        }

        private static XElement? GetNullableElement(
            this XDocument document,
            XNamespace @namespace,
            string elementName)
        {
            return document
               .Descendants(@namespace + elementName)
               .FirstOrDefault();
        }
    }
}
