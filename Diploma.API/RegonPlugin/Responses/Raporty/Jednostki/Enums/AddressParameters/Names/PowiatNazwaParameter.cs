// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Powiat, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Names
{
    public enum PowiatNazwaParameter
    {
        [XmlEnum("fiz_adSiedzPowiat_Nazwa")]
        fiz_adSiedzPowiat_Nazwa,

        [XmlEnum("lokpraw_adSiedzPowiat_Nazwa")]
        lokpraw_adSiedzPowiat_Nazwa,

        [XmlEnum("praw_adSiedzPowiat_Nazwa")]
        praw_adSiedzPowiat_Nazwa,

        [XmlEnum("lokfiz_adSiedzPowiat_Nazwa")]
        lokfiz_adSiedzPowiat_Nazwa,
    }
}
