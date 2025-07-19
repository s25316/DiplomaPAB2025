// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numer, Telefonu
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Contacts
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
