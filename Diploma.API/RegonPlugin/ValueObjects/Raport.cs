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
            ConfigurationData.RAPORT_PRAWNA,
            ConfigurationData.RAPORT_PRAWNA_PKD);

        private static Raport _lokalnaPrawna = new LokalnaPrawna(
            ConfigurationData.RAPORT_LOKALNA_PRAWNEJ,
            ConfigurationData.RAPORT_LOKALNA_PRAWNEJ_PKD);

        private static Raport _lokalnaFizyczna = new LokalnaFizyczna(
            ConfigurationData.RAPORT_LOKALNA_FIZYCZNEJ,
            ConfigurationData.RAPORT_LOKALNA_FIZYCZNEJ_PKD);

        private static Raport _fizycznaCEIDG = new Ceidg(
            ConfigurationData.RAPORT_FIZYCZNA_CEIDG,
            ConfigurationData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaRolnicza = new Rolnicza(
            ConfigurationData.RAPORT_FIZYCZNA_ROLNICZA,
            ConfigurationData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaPozostala = new Pozostala(
            ConfigurationData.RAPORT_FIZYCZNA_POZOSTALA,
            ConfigurationData.RAPORT_FIZYCZNA_PKD);

        private static Raport _fizycznaKRUPGN = new Krupgn(
            ConfigurationData.RAPORT_FIZYCZNA_W_KRUPGN,
            ConfigurationData.RAPORT_FIZYCZNA_PKD);



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
