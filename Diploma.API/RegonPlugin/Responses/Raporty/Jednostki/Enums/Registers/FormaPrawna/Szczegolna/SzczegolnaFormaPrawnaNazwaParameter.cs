// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Szczegolna, Forma, Prawna, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers.FormaPrawna.Szczegolna
{
    public enum SzczegolnaFormaPrawnaNazwaParameter
    {
        [XmlEnum("praw_szczegolnaFormaPrawna_Nazwa")]
        praw_szczegolnaFormaPrawna_Nazwa,

        [XmlEnum("lokpraw_szczegolnaFormaPrawna_Nazwa")]
        lokpraw_szczegolnaFormaPrawna_Nazwa,
    }
}
