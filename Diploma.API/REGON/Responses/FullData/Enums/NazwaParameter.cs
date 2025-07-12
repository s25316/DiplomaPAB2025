// Ignore Spelling: REGON, Enums, Nazwa
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums
{
    public enum NazwaParameter
    {
        [XmlEnum("fiz_nazwa")]
        fiz_nazwa,
        [XmlEnum("lokpraw_nazwa")]
        lokpraw_nazwa,
        [XmlEnum("praw_nazwa")]
        praw_nazwa,
        [XmlEnum("lokfiz_nazwa")]
        lokfiz_nazwa,
    }
}
