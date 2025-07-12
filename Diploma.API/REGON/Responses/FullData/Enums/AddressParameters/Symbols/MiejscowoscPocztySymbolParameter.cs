// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Symbols
{
    public enum MiejscowoscPocztySymbolParameter
    {
        [XmlEnum("fiz_adSiedzMiejscowoscPoczty_Symbol")]
        fiz_adSiedzMiejscowoscPoczty_Symbol,
        [XmlEnum("lokpraw_adSiedzMiejscowoscPoczty_Symbol")]
        lokpraw_adSiedzMiejscowoscPoczty_Symbol,
        [XmlEnum("praw_adSiedzMiejscowoscPoczty_Symbol")]
        praw_adSiedzMiejscowoscPoczty_Symbol,
        [XmlEnum("lokfiz_adSiedzMiejscowoscPoczty_Symbol")]
        lokfiz_adSiedzMiejscowoscPoczty_Symbol,
    }
}
