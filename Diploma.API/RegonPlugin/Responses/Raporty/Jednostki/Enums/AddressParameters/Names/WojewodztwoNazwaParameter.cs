﻿// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Wojewodztwo, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.AddressParameters.Names
{
    public enum WojewodztwoNazwaParameter
    {
        [XmlEnum("fiz_adSiedzWojewodztwo_Nazwa")]
        fiz_adSiedzWojewodztwo_Nazwa,

        [XmlEnum("lokpraw_adSiedzWojewodztwo_Nazwa")]
        lokpraw_adSiedzWojewodztwo_Nazwa,

        [XmlEnum("praw_adSiedzWojewodztwo_Nazwa")]
        praw_adSiedzWojewodztwo_Nazwa,

        [XmlEnum("lokfiz_adSiedzWojewodztwo_Nazwa")]
        lokfiz_adSiedzWojewodztwo_Nazwa,
    }
}
