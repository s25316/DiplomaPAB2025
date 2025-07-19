// Ignore Spelling: Regon, Plugin, Enums, Uslugi
using System.Text.Json.Serialization;

namespace RegonPlugin.Enums.GetValues
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusUslugi
    {
        UslugaNiedostepna = 0,
        UslugaDostepna = 1,
        PrzerwaTechniczna = 2,
    }
}
