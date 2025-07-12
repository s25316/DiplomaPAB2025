// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Symbols
{
    public enum PowiatSymbolParameter
    {
        [XmlEnum("fiz_adSiedzPowiat_Symbol")]
        fiz_adSiedzPowiat_Symbol,
        [XmlEnum("lokpraw_adSiedzPowiat_Symbol")]
        lokpraw_adSiedzPowiat_Symbol,
        [XmlEnum("praw_adSiedzPowiat_Symbol")]
        praw_adSiedzPowiat_Symbol,
        [XmlEnum("lokfiz_adSiedzPowiat_Symbol")]
        lokfiz_adSiedzPowiat_Symbol,
    }
}
