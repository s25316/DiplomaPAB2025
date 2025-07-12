// Ignore Spelling: REGON, Enums, Forma, Prawna, Szczegolna
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers.FormaPrawna.Szczegolna
{
    public enum SzczegolnaFormaPrawnaNazwaParameter
    {
        [XmlEnum("praw_szczegolnaFormaPrawna_Nazwa")]
        praw_szczegolnaFormaPrawna_Nazwa,
        [XmlEnum("lokpraw_szczegolnaFormaPrawna_Nazwa")]
        lokpraw_szczegolnaFormaPrawna_Nazwa,
    }
}
