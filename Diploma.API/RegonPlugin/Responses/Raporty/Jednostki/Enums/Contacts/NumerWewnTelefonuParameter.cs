// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Numer, Wewn, Telefonu
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Contacts
{
    public enum NumerWewnTelefonuParameter
    {
        [XmlEnum("fiz_numerWewnetrznyTelefonu")]
        fiz_numerWewnetrznyTelefonu,

        [XmlEnum("praw_numerWewnetrznyTelefonu")]
        praw_numerWewnetrznyTelefonu,

        [XmlEnum("fizC_numerWewnetrznyTelefonu")]
        fizC_numerWewnetrznyTelefonu,
    }
}
