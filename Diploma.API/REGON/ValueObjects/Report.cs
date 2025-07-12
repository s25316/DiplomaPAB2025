// Ignore Spelling: REGON, PKD, Typ, Jednostki, Lista, Jednostek, Lokalnych, Fizycznej, Wspolnicy
using REGON.Responses;

namespace REGON.ValueObjects
{
    internal readonly record struct Report
    {
        // Fields
        // F
        private const string TypeF = "f";
        private const string MainFOsoba = "PublDaneRaportFizycznaOsoba";
        private const string MainFCeidg = "PublDaneRaportDzialalnoscFizycznejCeidg";
        private const string MainFRolnicza = "PublDaneRaportDzialalnoscFizycznejRolnicza";
        private const string MainFPozostala = "PublDaneRaportDzialalnoscFizycznejPozostala";
        private const string MainFWKrupgn = "PublDaneRaportDzialalnoscFizycznejWKrupgn";
        private const string PkdF = "PublDaneRaportDzialalnosciFizycznej";
        private const string ListLF = "PublDaneRaportLokalneFizyczne";
        // LF 
        private const string TypeLF = "lf";
        private const string MainLF = "PublDaneRaportLokalnaFizycznej";
        private const string PkdLF = "PublDaneRaportDzialalnosciLokalnejFizycznej";
        // P
        private const string TypeP = "p";
        private const string MainP = "PublDaneRaportPrawna";
        private const string PkdP = "PublDaneRaportDzialalnosciPrawnej";
        private const string ListLP = "PublDaneRaportLokalnePrawnej";
        private const string WspolnicyP = "PublDaneRaportWspolnicyPrawnej";
        // LP
        private const string TypeLP = "lp";
        private const string MainLP = "PublDaneRaportLokalnaPrawnej";
        private const string PkdLP = "PublDaneRaportDzialalnosciLokalnejPrawnej";
        // ANY
        private const string Type = "PublDaneRaportTypJednostki";


        // Properties
        public static string TypJednostki => Type;
        public string Main { get; }
        public string PKD { get; }
        public string? ListaJednostekLokalnych { get; }
        public string? Wspolnicy { get; }


        // Constructor
        public Report(BaseDataResponse dane)
        {
            var type = dane.Typ.ToLowerInvariant();
            switch (type)
            {
                case TypeF:
                    Main = dane.SilosID switch
                    {
                        1 => MainFCeidg,
                        2 => MainFRolnicza,
                        3 => MainFPozostala,
                        4 => MainFWKrupgn,
                        _ => throw new NotImplementedException(MainFOsoba)
                    };
                    PKD = PkdF;
                    ListaJednostekLokalnych = ListLF; // Not Implemented
                    break;

                case TypeLF:
                    Main = MainLF;
                    PKD = PkdLF;
                    break;

                case TypeP:
                    Main = MainP;
                    PKD = PkdP;
                    ListaJednostekLokalnych = ListLP; // Not Implemented
                    Wspolnicy = WspolnicyP; // Not Implemented
                    break;

                case TypeLP:
                    Main = MainLP;
                    PKD = PkdLP;
                    break;

                default:
                    throw new NotImplementedException($"{type} : {dane.SilosID}");
            }
        }
    }
}
