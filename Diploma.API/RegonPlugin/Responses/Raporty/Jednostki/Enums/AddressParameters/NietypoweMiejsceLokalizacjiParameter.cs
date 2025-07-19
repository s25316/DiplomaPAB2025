// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Nietypowe, Miejsce, Lokalizacji
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters
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
