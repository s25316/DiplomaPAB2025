// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Nazwa, Skrocona
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums
{
    public enum NazwaSkroconaParameter
    {
        [XmlEnum("fiz_nazwaSkrocona")]
        fiz_nazwaSkrocona,

        [XmlEnum("praw_nazwaSkrocona")]
        praw_nazwaSkrocona,
    }
}
