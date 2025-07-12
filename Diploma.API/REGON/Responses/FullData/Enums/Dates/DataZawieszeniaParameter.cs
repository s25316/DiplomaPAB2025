// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Dates
{
    public enum DataZawieszeniaParameter
    {
        [XmlEnum("fiz_dataZawieszeniaDzialalnosci")]
        fiz_dataZawieszeniaDzialalnosci,
        [XmlEnum("lokpraw_dataZawieszeniaDzialalnosci")]
        lokpraw_dataZawieszeniaDzialalnosci,
        [XmlEnum("praw_dataZawieszeniaDzialalnosci")]
        praw_dataZawieszeniaDzialalnosci,
        [XmlEnum("lokfiz_dataZawieszeniaDzialalnosci")]
        lokfiz_dataZawieszeniaDzialalnosci,
    }
}
