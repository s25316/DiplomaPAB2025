// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Rodzaj, Rejestru
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers.RodzajRejestru
{
    public enum RodzajRejestruSymbolParameter
    {
        [XmlEnum("fizC_RodzajRejestru_Symbol")]
        fizC_RodzajRejestru_Symbol,

        [XmlEnum("fizP_RodzajRejestru_Symbol")]
        fizP_RodzajRejestru_Symbol,

        [XmlEnum("lokpraw_rodzajRejestruEwidencji_Symbol")]
        lokpraw_rodzajRejestruEwidencji_Symbol,

        [XmlEnum("praw_rodzajRejestruEwidencji_Symbol")]
        praw_rodzajRejestruEwidencji_Symbol,

        [XmlEnum("lokfiz_rodzajRejestru_Symbol")]
        lokfiz_rodzajRejestru_Nazwa,
    }
}
