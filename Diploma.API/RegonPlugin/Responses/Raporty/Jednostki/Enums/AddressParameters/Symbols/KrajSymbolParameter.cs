// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Kraj
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Symbols
{
    public enum KrajSymbolParameter
    {
        [XmlEnum("fiz_adSiedzKraj_Symbol")]
        fiz_adSiedzKraj_Symbol,

        [XmlEnum("lokpraw_adSiedzKraj_Symbol")]
        lokpraw_adSiedzKraj_Symbol,

        [XmlEnum("praw_adSiedzKraj_Symbol")]
        praw_adSiedzKraj_Symbol,

        [XmlEnum("lokfiz_adSiedzKraj_Symbol")]
        lokfiz_adSiedzKraj_Symbol,
    }
}
