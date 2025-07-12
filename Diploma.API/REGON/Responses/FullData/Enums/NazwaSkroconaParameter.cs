// Ignore Spelling: REGON, Enums, Nazwa, Skrocona
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums
{
    public enum NazwaSkroconaParameter
    {
        [XmlEnum("fiz_nazwaSkrocona")]
        fiz_nazwaSkrocona,
        [XmlEnum("praw_nazwaSkrocona")]
        praw_nazwaSkrocona,
    }
}
