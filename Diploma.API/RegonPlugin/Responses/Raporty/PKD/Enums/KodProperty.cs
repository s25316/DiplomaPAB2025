// Ignore Spelling: Regon, Plugin, Raporty, PKD, Enums, Kod
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.PKD.Enums
{
    public enum KodProperty
    {
        [XmlEnum("praw_pkdKod")]
        praw_pkdKod,

        [XmlEnum("lokpraw_pkdKod")]
        lokpraw_pkdKod,

        [XmlEnum("lokfiz_pkd_Kod")]
        lokfiz_pkd_Kod,

        [XmlEnum("fiz_pkd_Kod")]
        fiz_pkd_Kod,
    }
}
