// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Dates
{
    public enum DataZmianyParameter
    {
        [XmlEnum("fiz_dataZaistnieniaZmianyDzialalnosci")]
        fiz_dataZaistnieniaZmianyDzialalnosci,
        [XmlEnum("lokpraw_dataZaistnieniaZmiany")]
        lokpraw_dataZaistnieniaZmiany,
        [XmlEnum("praw_dataZaistnieniaZmiany")]
        praw_dataZaistnieniaZmiany,
        [XmlEnum("lokfiz_dataZaistnieniaZmiany")]
        lokfiz_dataZaistnieniaZmiany,
    }
}
