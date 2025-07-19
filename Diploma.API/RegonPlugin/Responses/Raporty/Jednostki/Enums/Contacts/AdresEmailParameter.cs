// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Adres
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Contacts
{
    public enum AdresEmailParameter
    {
        [XmlEnum("fiz_adresEmail")]
        fiz_adresEmail,

        [XmlEnum("praw_adresEmail")]
        praw_adresEmail,

        [XmlEnum("fizC_adresEmail")]
        fizC_adresEmail,

        [XmlEnum("fiz_adresEmail2")]
        fiz_adresEmail2,

        [XmlEnum("praw_adresEmail2")]
        praw_adresEmail2,
    }
}
