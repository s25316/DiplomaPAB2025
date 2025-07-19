// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numerw, Rejestrze, Ewidencji
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers
{
    public enum NumerwRejestrzeEwidencjiParameter
    {
        [XmlEnum("fizC_numerwRejestrzeEwidencji")]
        fizC_numerwRejestrzeEwidencji,

        [XmlEnum("fizP_numerwRejestrzeEwidencji")]
        fizP_numerwRejestrzeEwidencji,

        [XmlEnum("lokpraw_numerWrejestrzeEwidencji")]
        lokpraw_numerWrejestrzeEwidencji,

        [XmlEnum("praw_numerWrejestrzeEwidencji")]
        praw_numerWrejestrzeEwidencji,

        [XmlEnum("lokfiz_numerwRejestrzeEwidencji")]
        lokfiz_numerwRejestrzeEwidencji,
    }
}
