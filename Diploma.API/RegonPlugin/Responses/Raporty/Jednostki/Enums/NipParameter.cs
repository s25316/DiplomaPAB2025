// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums
{
    public enum NipParameter
    {
        [XmlEnum("lokpraw_nip")]
        lokpraw_nip,

        [XmlEnum("praw_nip")]
        praw_nip,
    }
}
