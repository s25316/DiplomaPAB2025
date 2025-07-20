// Ignore Spelling: Regon, Plugin, Raport
// Ignore Spelling: Fizyczna, Lokalna, Prawna, CEIDG, Krupgn, Rolnicza, Pozostala
using RegonPlugin.Enums;
using RegonPlugin.Responses;

namespace RegonPlugin.ValueObjects
{
    internal abstract record Raport(string Jednostki, string PKD)
    {
        public record Prawna(string Jednostki, string PKD) : Raport(Jednostki, PKD);
        public record LokalnaPrawna(string Jednostki, string PKD) : Raport(Jednostki, PKD);
        public record LokalnaFizyczna(string Jednostki, string PKD) : Raport(Jednostki, PKD);

        public abstract record Fizyczna(string Jednostki, string PKD) : Raport(Jednostki, PKD);
        public record Ceidg(string Jednostki, string PKD) : Fizyczna(Jednostki, PKD);
        public record Rolnicza(string Jednostki, string PKD) : Fizyczna(Jednostki, PKD);
        public record Pozostala(string Jednostki, string PKD) : Fizyczna(Jednostki, PKD);
        public record Krupgn(string Jednostki, string PKD) : Fizyczna(Jednostki, PKD);


        private static Raport _prawna = new Prawna(
            ConfigureData.RAPORT_PRAWNA,
            ConfigureData.RAPORT_PRAWNA_PKD);

        private static Raport _lokalnaPrawna = new LokalnaPrawna(
            ConfigureData.RAPORT_LOKALNA_PRAWNEJ,
            ConfigureData.RAPORT_LOKALNA_PRAWNEJ_PKD);

        private static Raport _lokalnaFizyczna = new LokalnaFizyczna(
            ConfigureData.RAPORT_LOKALNA_FIZYCZNEJ,
            ConfigureData.RAPORT_LOKALNA_FIZYCZNEJ_PKD);

        private static Raport _fizycznaCEIDG = new Ceidg(
            ConfigureData.RAPORT_FIZYCZNA_CEIDG,
            ConfigureData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaRolnicza = new Rolnicza(
            ConfigureData.RAPORT_FIZYCZNA_ROLNICZA,
            ConfigureData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaPozostala = new Pozostala(
            ConfigureData.RAPORT_FIZYCZNA_POZOSTALA,
            ConfigureData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaKRUPGN = new Krupgn(
            ConfigureData.RAPORT_FIZYCZNA_W_KRUPGN,
            ConfigureData.RAPORT_FIZYCZNA_PKD);



        public static implicit operator Raport(DaneSzukaj dane) => GetRaport(dane);
        public static Raport GetRaport(DaneSzukaj dane)
        {
            return dane switch
            {
                { Typ: TypJednostki.P } => _prawna,
                { Typ: TypJednostki.LP } => _lokalnaPrawna,
                { Typ: TypJednostki.LF } => _lokalnaFizyczna,
                { Typ: TypJednostki.F } and { SilosID: 1 } => _fizycznaCEIDG,
                { Typ: TypJednostki.F } and { SilosID: 2 } => _fizycznaRolnicza,
                { Typ: TypJednostki.F } and { SilosID: 3 } => _fizycznaPozostala,
                { Typ: TypJednostki.F } and { SilosID: 4 } => _fizycznaKRUPGN,
                _ => throw new NotImplementedException(dane.ToString())
            };
        }
    }
}
