// Ignore Spelling: Regon, Plugin, Raporty, Enums, Typ, Jednostki
using RegonPlugin.Enums;
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty
{
    public record TypJednostki
    {
        [XmlElement("Typ", IsNullable = false)]
        public Enums.TypJednostki Typ { get; init; }
    }
}
