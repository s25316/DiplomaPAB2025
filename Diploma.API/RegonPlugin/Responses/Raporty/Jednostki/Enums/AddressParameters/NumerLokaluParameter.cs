// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numer, Lokalu
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters
{
    public enum NumerLokaluParameter
    {
        [XmlEnum("fiz_adSiedzNumerLokalu")]
        fiz_adSiedzNumerLokalu,

        [XmlEnum("lokpraw_adSiedzNumerLokalu")]
        lokpraw_adSiedzNumerLokalu,

        [XmlEnum("praw_adSiedzNumerLokalu")]
        praw_adSiedzNumerLokalu,

        [XmlEnum("lokfiz_adSiedzNumerLokalu")]
        lokfiz_adSiedzNumerLokalu,
    }
}
