// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Names
{
    public enum MiejscowoscPocztyNazwaParameter
    {
        [XmlEnum("fiz_adSiedzMiejscowoscPoczty_Nazwa")]
        fiz_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("lokpraw_adSiedzMiejscowoscPoczty_Nazwa")]
        lokpraw_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("praw_adSiedzMiejscowoscPoczty_Nazwa")]
        praw_adSiedzMiejscowoscPoczty_Nazwa,
        [XmlEnum("lokfiz_adSiedzMiejscowoscPoczty_Nazwa")]
        lokfiz_adSiedzMiejscowoscPoczty_Nazwa,
    }
}
