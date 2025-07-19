// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Powiat
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Symbols
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
