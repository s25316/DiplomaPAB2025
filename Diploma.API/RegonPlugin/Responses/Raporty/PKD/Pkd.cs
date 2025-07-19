// Ignore Spelling: Regon, Plugin, Raporty, PKD, Enums, Kod, Nazwa, Przewazajace
using RegonPlugin.Responses.Raporty.PKD.Enums;
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.PKD
{
    public record Pkd
    {
        [XmlChoiceIdentifier("KodProperty")]
        [XmlElement(ElementName = "fiz_pkd_Kod")]
        [XmlElement(ElementName = "lokfiz_pkd_Kod")]
        [XmlElement(ElementName = "praw_pkdKod")]
        [XmlElement(ElementName = "lokpraw_pkdKod")]
        public string Kod { get; init; } = null!;
        public KodProperty KodProperty { get; init; }


        [XmlChoiceIdentifier("NazwaProperty")]
        [XmlElement(ElementName = "fiz_pkd_Nazwa")]
        [XmlElement(ElementName = "lokfiz_pkd_Nazwa")]
        [XmlElement(ElementName = "praw_pkdNazwa")]
        [XmlElement(ElementName = "lokpraw_pkdNazwa")]
        public string Nazwa { get; init; } = null!;
        public NazwaProperty NazwaProperty { get; init; }


        [XmlChoiceIdentifier("PrzewazajaceProperty")]
        [XmlElement(ElementName = "fiz_pkd_Przewazajace")]
        [XmlElement(ElementName = "lokfiz_pkd_Przewazajace")]
        [XmlElement(ElementName = "praw_pkdPrzewazajace")]
        [XmlElement(ElementName = "lokpraw_pkdPrzewazajace")]
        public string Przewazajace { get; init; } = null!;
        public PrzewazajaceProperty PrzewazajaceProperty { get; init; }


        [XmlChoiceIdentifier("SilosProperty")]
        [XmlElement(ElementName = "fiz_Silos_Symbol")]
        [XmlElement(ElementName = "lokfiz_Silos_Symbol")]
        public string? Silos { get; init; } = null;
        public SilosProperty SilosProperty { get; init; }
    }
}
