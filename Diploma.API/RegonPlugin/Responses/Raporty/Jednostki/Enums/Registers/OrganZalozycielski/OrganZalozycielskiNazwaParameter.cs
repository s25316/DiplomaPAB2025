// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Zalozycielski, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers.OrganZalozycielski
{
    public enum OrganZalozycielskiNazwaParameter
    {
        [XmlEnum("praw_organZalozycielski_Nazwa")]
        praw_organZalozycielski_Nazwa,

        [XmlEnum("lokpraw_organZalozycielski_Nazwa")]
        lokpraw_organZalozycielski_Nazwa,
    }
}
