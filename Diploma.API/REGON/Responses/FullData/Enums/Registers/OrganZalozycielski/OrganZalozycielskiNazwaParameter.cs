// Ignore Spelling: REGON, Enums, Forma, Zalozycielski
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers.OrganZalozycielski
{
    public enum OrganZalozycielskiNazwaParameter
    {
        [XmlEnum("praw_organZalozycielski_Nazwa")]
        praw_organZalozycielski_Nazwa,
        [XmlEnum("lokpraw_organZalozycielski_Nazwa")]
        lokpraw_organZalozycielski_Nazwa,
    }
}
