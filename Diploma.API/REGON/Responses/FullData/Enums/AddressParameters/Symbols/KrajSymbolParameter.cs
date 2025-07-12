// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Symbols
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
