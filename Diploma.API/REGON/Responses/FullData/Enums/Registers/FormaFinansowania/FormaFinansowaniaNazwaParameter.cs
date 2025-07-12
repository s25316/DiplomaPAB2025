// Ignore Spelling: REGON, Enums, Forma, Finansowania
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers.FormaFinansowania
{
    public enum FormaFinansowaniaNazwaParameter
    {
        [XmlEnum("praw_formaFinansowania_Nazwa")]
        praw_formaFinansowania_Nazwa,
        [XmlEnum("lokfiz_formaFinansowania_Nazwa")]
        lokfiz_formaFinansowania_Nazwa,
        [XmlEnum("lokpraw_formaFinansowania_Nazwa")]
        lokpraw_formaFinansowania_Nazwa,
    }
}
