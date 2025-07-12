// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Dates
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
