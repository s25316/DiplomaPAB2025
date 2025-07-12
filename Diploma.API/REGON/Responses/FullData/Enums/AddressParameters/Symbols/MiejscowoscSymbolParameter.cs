// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Symbols
{
    public enum MiejscowoscSymbolParameter
    {
        [XmlEnum("fiz_adSiedzMiejscowosc_Symbol")]
        fiz_adSiedzMiejscowosc_Symbol,
        [XmlEnum("lokpraw_adSiedzMiejscowosc_Symbol")]
        lokpraw_adSiedzMiejscowosc_Symbol,
        [XmlEnum("praw_adSiedzMiejscowosc_Symbol")]
        praw_adSiedzMiejscowosc_Symbol,
        [XmlEnum("lokfiz_adSiedzMiejscowosc_Symbol")]
        lokfiz_adSiedzMiejscowosc_Symbol,
    }
}
