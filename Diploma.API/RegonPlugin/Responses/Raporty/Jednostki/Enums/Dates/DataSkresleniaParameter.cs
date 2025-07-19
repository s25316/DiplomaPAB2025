// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Skreslenia
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Dates
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
