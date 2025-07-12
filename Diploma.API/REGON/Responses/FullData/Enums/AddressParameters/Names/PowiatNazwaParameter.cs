// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Names
{
    public enum PowiatNazwaParameter
    {
        [XmlEnum("fiz_adSiedzPowiat_Nazwa")]
        fiz_adSiedzPowiat_Nazwa,
        [XmlEnum("lokpraw_adSiedzPowiat_Nazwa")]
        lokpraw_adSiedzPowiat_Nazwa,
        [XmlEnum("praw_adSiedzPowiat_Nazwa")]
        praw_adSiedzPowiat_Nazwa,
        [XmlEnum("lokfiz_adSiedzPowiat_Nazwa")]
        lokfiz_adSiedzPowiat_Nazwa,
    }
}
