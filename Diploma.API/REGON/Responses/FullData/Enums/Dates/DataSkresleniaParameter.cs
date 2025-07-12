// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Dates
{
    public enum DataSkresleniaParameter
    {
        [XmlEnum("fiz_dataSkresleniazRegonDzialalnosci")]
        fiz_dataSkresleniazRegonDzialalnosci,
        [XmlEnum("lokpraw_dataSkresleniazRegon")]
        lokpraw_dataSkresleniazRegon,
        [XmlEnum("praw_dataSkresleniazRegon")]
        praw_dataSkresleniazRegon,
        [XmlEnum("lokfiz_dataSkresleniazRegon")]
        lokfiz_dataSkresleniazRegon,
    }
}
