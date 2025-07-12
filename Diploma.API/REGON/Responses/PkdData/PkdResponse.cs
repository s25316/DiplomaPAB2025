// Ignore Spelling: REGON, Pkd, Kod, Nazwa, Przewazajace
using REGON.Responses.PkdData.Enums;
using System.Xml.Serialization;

namespace REGON.Responses.PkdData
{
    public class PkdResponse
    {
        [XmlChoiceIdentifier("KodProperty")]
        [XmlElement(ElementName = "praw_pkdKod")]
        [XmlElement(ElementName = "lokpraw_pkdKod")]
        [XmlElement(ElementName = "lokfiz_pkd_Kod")]
        [XmlElement(ElementName = "fiz_pkd_Kod")]
        public string Kod { get; init; } = null!;
        public KodProperty KodProperty { get; init; }


        [XmlChoiceIdentifier("NazwaProperty")]
        [XmlElement(ElementName = "praw_pkdNazwa")]
        [XmlElement(ElementName = "lokpraw_pkdNazwa")]
        [XmlElement(ElementName = "lokfiz_pkd_Nazwa")]
        [XmlElement(ElementName = "fiz_pkd_Nazwa")]
        public string Nazwa { get; init; } = null!;
        public NazwaProperty NazwaProperty { get; init; }


        [XmlChoiceIdentifier("PrzewazajaceProperty")]
        [XmlElement(ElementName = "praw_pkdPrzewazajace")]
        [XmlElement(ElementName = "lokpraw_pkdPrzewazajace")]
        [XmlElement(ElementName = "lokfiz_pkd_Przewazajace")]
        [XmlElement(ElementName = "fiz_pkd_Przewazajace")]
        public string Przewazajace { get; init; } = null!;
        public PrzewazajaceProperty PrzewazajaceProperty { get; init; }
    }
}
