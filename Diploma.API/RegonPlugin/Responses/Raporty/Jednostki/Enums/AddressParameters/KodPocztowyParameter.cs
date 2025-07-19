// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Kod, Pocztowy
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters
{
    public enum KodPocztowyParameter
    {
        [XmlEnum("fiz_adSiedzKodPocztowy")]
        fiz_adSiedzKodPocztowy,

        [XmlEnum("lokpraw_adSiedzKodPocztowy")]
        lokpraw_adSiedzKodPocztowy,

        [XmlEnum("praw_adSiedzKodPocztowy")]
        praw_adSiedzKodPocztowy,

        [XmlEnum("lokfiz_adSiedzKodPocztowy")]
        lokfiz_adSiedzKodPocztowy,
    }
}
