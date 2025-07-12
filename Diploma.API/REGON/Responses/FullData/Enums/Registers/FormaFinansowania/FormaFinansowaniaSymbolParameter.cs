// Ignore Spelling: REGON, Enums, Forma, Finansowania
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers.FormaFinansowania
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
