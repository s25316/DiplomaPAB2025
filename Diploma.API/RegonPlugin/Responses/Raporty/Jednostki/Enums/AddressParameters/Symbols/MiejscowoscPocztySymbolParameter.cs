// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Miejscowosc, Poczty
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Symbols
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
