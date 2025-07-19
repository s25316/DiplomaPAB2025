// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numer, Nieruchomosci
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters
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
