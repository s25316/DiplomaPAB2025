// Ignore Spelling: Regon, Plugin, Raporty, PKD, Enums, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.PKD.Enums
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
