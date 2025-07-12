// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.AddressParameters.Names
{
    public enum KrajNazwaParameter
    {
        [XmlEnum("fiz_adSiedzKraj_Nazwa")]
        fiz_adSiedzKraj_Nazwa,
        [XmlEnum("lokpraw_adSiedzKraj_Nazwa")]
        lokpraw_adSiedzKraj_Nazwa,
        [XmlEnum("praw_adSiedzKraj_Nazwa")]
        praw_adSiedzKraj_Nazwa,
        [XmlEnum("lokfiz_adSiedzKraj_Nazwa")]
        lokfiz_adSiedzKraj_Nazwa,
    }
}
