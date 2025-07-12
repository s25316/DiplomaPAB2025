// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Registers
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
