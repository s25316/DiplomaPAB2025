// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters
{
    public enum NietypoweMiejsceLokalizacjiParameter
    {
        [XmlEnum("fiz_adSiedzNietypoweMiejsceLokalizacji")]
        fiz_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("lokpraw_adSiedzNietypoweMiejsceLokalizacji")]
        lokpraw_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("praw_adSiedzNietypoweMiejsceLokalizacji")]
        praw_adSiedzNietypoweMiejsceLokalizacji,
        [XmlEnum("lokfiz_adSiedzNietypoweMiejsceLokalizacji")]
        lokfiz_adSiedzNietypoweMiejsceLokalizacji,
    }
}
