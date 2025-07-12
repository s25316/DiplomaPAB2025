// Ignore Spelling: REGON, Dane, Szukaj, Nazwa, Wojewodztwo, Powiat, Gmina, Miejscowosc, Kod, Pocztowy, Ulica, Typ
using System.Xml.Serialization;

namespace REGON.Responses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public record BaseDataResponse
    {
        [XmlElement(ElementName = "Regon")]
        public string Regon { get; init; } = null!;

        [XmlElement(ElementName = "RegonLink")]
        public string RegonLink { get; init; } = null!;

        [XmlElement(ElementName = "Nazwa")]
        public string Nazwa { get; init; } = null!;

        [XmlElement(ElementName = "Wojewodztwo")]
        public string? Wojewodztwo { get; init; } = null;

        [XmlElement(ElementName = "Powiat")]
        public string? Powiat { get; init; } = null;

        [XmlElement(ElementName = "Gmina")]
        public string? Gmina { get; init; } = null;

        [XmlElement(ElementName = "Miejscowosc")]
        public string? Miejscowosc { get; init; } = null;

        [XmlElement(ElementName = "KodPocztowy")]
        public string? KodPocztowy { get; init; } = null;

        [XmlElement(ElementName = "Ulica")]
        public string? Ulica { get; init; } = null;

        [XmlElement(ElementName = "Typ")]
        public string Typ { get; init; } = null!;

        [XmlElement(ElementName = "SilosID")]
        public int? SilosID { get; init; } = null;
    }
}
