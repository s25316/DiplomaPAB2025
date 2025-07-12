// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters
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
