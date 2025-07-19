// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Wznowienia
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Dates
{
    public enum DataWznowieniaParameter
    {
        [XmlEnum("fiz_dataWznowieniaDzialalnosci")]
        fiz_dataWznowieniaDzialalnosci,

        [XmlEnum("lokpraw_dataWznowieniaDzialalnosci")]
        lokpraw_dataWznowieniaDzialalnosci,

        [XmlEnum("praw_dataWznowieniaDzialalnosci")]
        praw_dataWznowieniaDzialalnosci,

        [XmlEnum("lokfiz_dataWznowieniaDzialalnosci")]
        lokfiz_dataWznowieniaDzialalnosci,
    }
}
