// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters
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
