// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Symbols
{
    public enum GminaSymbolParameter
    {
        [XmlEnum("fiz_adSiedzGmina_Symbol")]
        fiz_adSiedzGmina_Symbol,
        [XmlEnum("lokpraw_adSiedzGmina_Symbol")]
        lokpraw_adSiedzGmina_Symbol,
        [XmlEnum("praw_adSiedzGmina_Symbol")]
        praw_adSiedzGmina_Symbol,
        [XmlEnum("lokfiz_adSiedzGmina_Symbol")]
        lokfiz_adSiedzGmina_Symbol,
    }
}
