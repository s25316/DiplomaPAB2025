// Ignore Spelling: REGON, Pkd, Enums, Nazwa
using System.Xml.Serialization;

namespace REGON.Responses.PkdData.Enums
{
    public enum NazwaProperty
    {
        [XmlEnum("praw_pkdNazwa")]
        praw_pkdNazwa,
        [XmlEnum("lokpraw_pkdNazwa")]
        lokpraw_pkdNazwa,
        [XmlEnum("lokfiz_pkd_Nazwa")]
        lokfiz_pkd_Nazwa,
        [XmlEnum("fiz_pkd_Nazwa")]
        fiz_pkd_Nazwa,
    }
}
