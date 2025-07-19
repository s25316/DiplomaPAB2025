// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numer, Faksu
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Contacts
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
