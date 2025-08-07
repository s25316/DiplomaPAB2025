// ignore Spelling: Teryt, Plugin, Miejscowosc
// ignore Spelling: część, miejscowości, wieś, kolonia, przysiółek, osada, leśna, osiedle, schronisko, turystyczne,
// ignore Spelling: dzielnica, Warszawy, miasto, delegatura, miasta, Czesc, Przysiolek, Wies
namespace TerytPlugin.Models
{
    public record MiejscowoscType(int Id, string Name)
    {
        public static MiejscowoscType Czesc => new MiejscowoscType(0, "część miejscowości");
        public static MiejscowoscType Wies => new MiejscowoscType(1, "wieś");
        public static MiejscowoscType Kolonia => new MiejscowoscType(2, "kolonia");
        public static MiejscowoscType Przysiolek => new MiejscowoscType(3, "przysiółek");
        public static MiejscowoscType Osada => new MiejscowoscType(4, "osada");
        public static MiejscowoscType OsadaLeśna => new MiejscowoscType(5, "osada leśna");
        public static MiejscowoscType Osiedle => new MiejscowoscType(6, "osiedle");
        public static MiejscowoscType SchroniskoTurystyczne => new MiejscowoscType(7, "schronisko turystyczne");
        public static MiejscowoscType Dzielnica => new MiejscowoscType(95, "dzielnica m. st. Warszawy");
        public static MiejscowoscType Miasto => new MiejscowoscType(96, "miasto");
        public static MiejscowoscType Delegatura => new MiejscowoscType(98, "delegatura");
        public static MiejscowoscType CzescMiasta => new MiejscowoscType(99, "część miasta");
        public static Dictionary<int, MiejscowoscType> Types => new Dictionary<int, MiejscowoscType>
        {
            { 0, Czesc},
            { 1, Wies},
            { 2, Kolonia},
            { 3, Przysiolek},
            { 4, Osada},
            { 5, OsadaLeśna},
            { 6, Osiedle},
            { 7, SchroniskoTurystyczne},
            { 95, Dzielnica},
            { 96, Miasto},
            { 98, Delegatura},
            { 99, CzescMiasta},
        };


        public static implicit operator MiejscowoscType(string value)
        {
            if (!Types.TryGetValue(int.Parse(value), out var item))
            {
                throw new NotImplementedException(value);
            }
            return item;
        }
    }
}
