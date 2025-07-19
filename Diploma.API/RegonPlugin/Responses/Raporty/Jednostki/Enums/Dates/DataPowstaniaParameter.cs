// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Powstania
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Dates
{
    public enum DataPowstaniaParameter
    {
        [XmlEnum("fiz_dataPowstania")]
        fiz_dataPowstania,

        [XmlEnum("lokpraw_dataPowstania")]
        lokpraw_dataPowstania,

        [XmlEnum("praw_dataPowstania")]
        praw_dataPowstania,

        [XmlEnum("lokfiz_dataPowstania")]
        lokfiz_dataPowstania,
    }
}
