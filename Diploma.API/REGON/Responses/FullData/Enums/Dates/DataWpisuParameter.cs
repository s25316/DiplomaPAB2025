// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Dates
{
    public enum DataWpisuParameter
    {
        [XmlEnum("fiz_dataWpisuDoREGONDzialalnosci")]
        fiz_dataWpisuDoREGONDzialalnosci,
        [XmlEnum("lokpraw_dataWpisuDoREGON")]
        lokpraw_dataWpisuDoREGON,
        [XmlEnum("praw_dataWpisuDoREGON")]
        praw_dataWpisuDoREGON,
        [XmlEnum("lokfiz_dataWpisuDoREGON")]
        lokfiz_dataWpisuDoREGON,
    }
}
