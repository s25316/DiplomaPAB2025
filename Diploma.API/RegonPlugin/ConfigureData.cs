// Ignore Spelling: Regon, Plugin
// Ignore Spelling: RAPORT, TYP, JEDNOSTKI, PKD, LOKALNA, 
// Ignore Spelling: PRAWNA, PRAWNEJ, FIZYCZNA, FIZYCZNEJ, WSPOLNICY, ZALOGUJ, WYLOGUJ
// Ignore Spelling: CEIDG, ROLNICZA, POZOSTALA, KRUPGN, LISTA, LF, sid, xml, dane
namespace RegonPlugin
{
    internal static class ConfigureData
    {
        //=================================================================================
        // REQUESTS PART
        //=================================================================================

        // ENDPOINTY 
        public const string PRODUCTION_ENDPOINT = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";

        public const string TESTING_ENDPOINT = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";


        // REQUEST DATA
        public const string HEADER_NAME_SESSION_ID = "sid";

        public const string REQUEST_MEDIA_TYPE = "application/soap+xml";


        // RAPORTY
        public const string RAPORT_TYP_JEDNOSTKI = "PublDaneRaportTypJednostki";

        // PKD RAPORTY
        public const string RAPORT_FIZYCZNA_PKD = "PublDaneRaportDzialalnosciFizycznej";

        public const string RAPORT_PRAWNA_PKD = "PublDaneRaportDzialalnosciPrawnej";

        public const string RAPORT_LOKALNA_FIZYCZNEJ_PKD = "PublDaneRaportDzialalnosciLokalnejFizycznej";

        public const string RAPORT_LOKALNA_PRAWNEJ_PKD = "PublDaneRaportDzialalnosciLokalnejPrawnej";

        // RAPORTY
        public const string RAPORT_PRAWNA = "PublDaneRaportPrawna";

        public const string RAPORT_LOKALNA_PRAWNEJ = "PublDaneRaportLokalnaPrawnej";

        public const string RAPORT_LOKALNA_FIZYCZNEJ = "PublDaneRaportLokalnaFizycznej";


        public const string RAPORT_FIZYCZNA = "PublDaneRaportFizycznaOsoba";

        public const string RAPORT_FIZYCZNA_CEIDG = "PublDaneRaportDzialalnoscFizycznejCeidg";

        public const string RAPORT_FIZYCZNA_ROLNICZA = "PublDaneRaportDzialalnoscFizycznejRolnicza";

        public const string RAPORT_FIZYCZNA_POZOSTALA = "PublDaneRaportDzialalnoscFizycznejPozostala";

        public const string RAPORT_FIZYCZNA_W_KRUPGN = "PublDaneRaportDzialalnoscFizycznejWKrupgn";

        // LISTA JEDNOSTEK 
        public const string RAPORT_PRAWNA_LISTA_LP = "PublDaneRaportLokalnePrawnej";

        public const string RAPORT_FIZYCZNA_LISTA_LF = "PublDaneRaportLokalneFizycznej";

        // WSPOLNICY
        public const string RAPORT_PRAWNA_WSPOLNICY = "PublDaneRaportWspolnicyPrawnej";


        //=================================================================================
        // RESPONSES PART
        //=================================================================================

        // RESPONSES ELEMENTS
        public const string RESPONSE_ELEMENT_ZALOGUJ = "ZalogujResult";

        public const string RESPONSE_ELEMENT_WYLOGUJ = "WylogujResult";

        public const string RESPONSE_ELEMENT_GET_VALUE_RESULT = "GetValueResult";

        public const string RESPONSE_ELEMENT_ROOT = "root";

        public const string RESPONSE_ELEMENT_DANE = "dane";

        // NAMESPACES 
        public const string NAMESPACE = "http://CIS/BIR/PUBL/2014/07";

        public const string NAMESPACE_GET_VALUE_RESULT = "http://CIS/BIR/2014/07";

        //=================================================================================
        // OTHER
        //=================================================================================

        // REGEX
        // Sometimes Returns REGON with 5 zeros, and this removes
        public const string REGEX_REGON_REPLACE_ZEROS = @"^(\d{9})(0{5})$";
    }
}
