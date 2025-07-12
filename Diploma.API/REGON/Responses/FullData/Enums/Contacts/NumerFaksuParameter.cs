// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Contacts
{
    public enum NumerFaksuParameter
    {
        [XmlEnum("fiz_numerFaksu")]
        fiz_numerFaksu,
        [XmlEnum("praw_numerFaksu")]
        praw_numerFaksu,
        [XmlEnum("fizC_numerFaksu")]
        fizC_numerFaksu,
    }
}
