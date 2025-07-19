// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Rozpoczecia
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Dates
{
    public enum DataRozpoczeciaParameter
    {
        [XmlEnum("fiz_dataRozpoczeciaDzialalnosci")]
        fiz_dataRozpoczeciaDzialalnosci,

        [XmlEnum("lokpraw_dataRozpoczeciaDzialalnosci")]
        lokpraw_dataRozpoczeciaDzialalnosci,

        [XmlEnum("praw_dataRozpoczeciaDzialalnosci")]
        praw_dataRozpoczeciaDzialalnosci,

        [XmlEnum("lokfiz_dataRozpoczeciaDzialalnosci")]
        lokfiz_dataRozpoczeciaDzialalnosci,
    }
}
