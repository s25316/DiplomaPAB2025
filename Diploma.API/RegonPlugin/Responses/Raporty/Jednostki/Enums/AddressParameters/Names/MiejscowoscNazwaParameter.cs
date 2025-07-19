// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Miejscowosc, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Names
{
    public enum MiejscowoscNazwaParameter
    {
        [XmlEnum("fiz_adSiedzMiejscowosc_Nazwa")]
        fiz_adSiedzMiejscowosc_Nazwa,

        [XmlEnum("lokpraw_adSiedzMiejscowosc_Nazwa")]
        lokpraw_adSiedzMiejscowosc_Nazwa,

        [XmlEnum("praw_adSiedzMiejscowosc_Nazwa")]
        praw_adSiedzMiejscowosc_Nazwa,

        [XmlEnum("lokfiz_adSiedzMiejscowosc_Nazwa")]
        lokfiz_adSiedzMiejscowosc_Nazwa,
    }
}
