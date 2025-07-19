// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums
{
    public enum RegonParameter
    {
        [XmlEnum("fiz_regon9")]
        fiz_regon9,

        [XmlEnum("lokpraw_regon14")]
        lokpraw_regon14,

        [XmlEnum("praw_regon14")]
        praw_regon14,

        [XmlEnum("lokfiz_regon14")]
        lokfiz_regon14,
    }
}
