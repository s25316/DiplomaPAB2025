// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Forma, Finansowania, 
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers.FormaFinansowania
{
    public enum FormaFinansowaniaSymbolParameter
    {
        [XmlEnum("praw_formaFinansowania_Symbol")]
        praw_formaFinansowania_Symbol,

        [XmlEnum("lokfiz_formaFinansowania_Symbol")]
        lokfiz_formaFinansowania_Symbol,

        [XmlEnum("lokpraw_formaFinansowania_Symbol")]
        lokpraw_formaFinansowania_Symbol,
    }
}
