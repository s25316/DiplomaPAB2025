﻿// Ignore Spelling: Regon, Plugin, Raporty, Jednostki, Enums, Forma, Wlasnosci, Nazwa
using System.Xml.Serialization;

namespace RegonPlugin.Responses.Raporty.Jednostki.Enums.Registers.FormaWlasnosci
{
    public enum FormaWlasnosciNazwaParameter
    {
        [XmlEnum("praw_formaWlasnosci_Nazwa")]
        praw_formaWlasnosci_Nazwa,

        [XmlEnum("lokpraw_formaWlasnosci_Nazwa")]
        lokpraw_formaWlasnosci_Nazwa,
    }
}
