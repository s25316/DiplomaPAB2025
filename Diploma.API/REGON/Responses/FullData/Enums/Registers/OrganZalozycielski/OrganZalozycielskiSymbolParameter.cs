// Ignore Spelling: REGON, Enums, Forma, Zalozycielski
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers.OrganZalozycielski
{
    public enum OrganZalozycielskiSymbolParameter
    {
        [XmlEnum("praw_organZalozycielski_Symbol")]
        praw_organZalozycielski_Symbol,
        [XmlEnum("lokpraw_organZalozycielski_Symbol")]
        lokpraw_organZalozycielski_Symbol,
    }
}
