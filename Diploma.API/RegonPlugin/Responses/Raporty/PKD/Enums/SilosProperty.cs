// Ignore Spelling: Regon, Plugin, Raporty, PKD, Enums
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.PKD.Enums
{
    public enum SilosProperty
    {
        [XmlEnum("fiz_Silos_Symbol")]
        fiz_Silos_Symbol,

        [XmlEnum("lokfiz_Silos_Symbol")]
        lokfiz_Silos_Symbol,
    }
}
