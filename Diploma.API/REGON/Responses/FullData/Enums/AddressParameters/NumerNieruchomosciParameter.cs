// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters
{
    public enum NumerNieruchomosciParameter
    {
        [XmlEnum("fiz_adSiedzNumerNieruchomosci")]
        fiz_adSiedzNumerNieruchomosci,
        [XmlEnum("lokpraw_adSiedzNumerNieruchomosci")]
        lokpraw_adSiedzNumerNieruchomosci,
        [XmlEnum("praw_adSiedzNumerNieruchomosci")]
        praw_adSiedzNumerNieruchomosci,
        [XmlEnum("lokfiz_adSiedzNumerNieruchomosci")]
        lokfiz_adSiedzNumerNieruchomosci,
    }
}
