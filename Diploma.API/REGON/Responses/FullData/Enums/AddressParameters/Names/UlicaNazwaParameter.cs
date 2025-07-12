// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Names
{
    public enum UlicaNazwaParameter
    {
        [XmlEnum("fiz_adSiedzUlica_Nazwa")]
        fiz_adSiedzUlica_Nazwa,
        [XmlEnum("lokpraw_adSiedzUlica_Nazwa")]
        lokpraw_adSiedzUlica_Nazwa,
        [XmlEnum("praw_adSiedzUlica_Nazwa")]
        praw_adSiedzUlica_Nazwa,
        [XmlEnum("lokfiz_adSiedzUlica_Nazwa")]
        lokfiz_adSiedzUlica_Nazwa,
    }
}
