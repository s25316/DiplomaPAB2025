// Ignore Spelling: Regon, Enums,
// Ignore Spelling: Wywołanie nie wymaga przekazania dodatkowego nagłówka SID w żądaniu http.
namespace REGON.Enums.GetValues
{
    internal enum GetValue
    {
        StanDanych = 1,
        KomunikatKod,
        KomunikatTresc,
        StatusSesji,

        /// <summary>
        /// Wywołanie nie wymaga przekazania dodatkowego nagłówka SID w żądaniu http.
        /// </summary>
        StatusUslugi,

        /// <summary>
        /// Wywołanie nie wymaga przekazania dodatkowego nagłówka SID w żądaniu http.
        /// </summary>
        KomunikatUslugi,
    }
}
