// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums
{
    public enum NipParameter
    {
        [XmlEnum("lokpraw_nip")]
        lokpraw_nip,
        [XmlEnum("praw_nip")]
        praw_nip,
    }
}
