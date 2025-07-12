// Ignore Spelling: REGON, Enums
using System.Xml.Serialization;

namespace REGON.Responses.FullData.Enums.Contacts
{
    public enum NumerTelefonuParameter
    {
        [XmlEnum("fiz_numerTelefonu")]
        fiz_numerTelefonu,
        [XmlEnum("praw_numerTelefonu")]
        praw_numerTelefonu,
        [XmlEnum("fizC_numerTelefonu")]
        fizC_numerTelefonu,
    }
}
