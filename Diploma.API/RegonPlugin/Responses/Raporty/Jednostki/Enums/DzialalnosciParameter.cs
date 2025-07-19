// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Dzialalnosci
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums
{
    public enum DzialalnosciParameter
    {
        [XmlEnum("praw_jednostekLokalnych")]
        praw_jednostekLokalnych,

        [XmlEnum("lokfiz_dzialalnosci")]
        lokfiz_dzialalnosci,

        [XmlEnum("lokpraw_dzialalnosci")]
        lokpraw_dzialalnosci,
    }
}
