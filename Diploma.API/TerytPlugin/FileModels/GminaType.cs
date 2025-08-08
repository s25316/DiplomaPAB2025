// Ignore Spelling: Teryt, Plugin, Jednostka,  obszar, 
// Ignore Spelling: województwo, Wojewodztwo, Gmina, gminie, powiat, powiatu,
// Ignore Spelling: miejska, miejsko, miasto, wiejska, miasta, wiejskiej, wiejski
// Ignore Spelling: dzielnica, delegatura, Warszawa, na, prawach
namespace TerytPlugin.FileModels
{
    public record GminaType(int Id, string Name)
    {
        public static GminaType GminaMiejska => new GminaType(1, "gmina miejska");
        public static GminaType GminaWiejska => new GminaType(2, "gmina wiejska");
        public static GminaType GminaMiejskoWiejska => new GminaType(3, "gmina miejsko-wiejska");
        public static GminaType MiastoWMiejskoWiejskiej => new GminaType(4, "miasto w gminie miejsko-wiejskiej");
        public static GminaType ObszarWiejskiWMiejskoWiejskiej => new GminaType(5, "obszar wiejski w gminie miejsko-wiejskiej");
        public static GminaType Dzielnica => new GminaType(8, "dzielnica w m.st. Warszawa");
        public static GminaType Delegatura => new GminaType(9, "delegatura miasta");

        public static IReadOnlyDictionary<int, GminaType> Types => new Dictionary<int, GminaType>()
        {
            { 1, GminaMiejska},
            { 2, GminaWiejska},
            { 3, GminaMiejskoWiejska},
            { 4, MiastoWMiejskoWiejskiej},
            { 5, ObszarWiejskiWMiejskoWiejskiej},
            { 8, Dzielnica},
            { 9, Delegatura},
        };


        public static implicit operator GminaType?(string? value)
        {
            value = Adapt(value);
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return Types[int.Parse(value)];
        }

        private static string? Adapt(string? value)
        {
            return !string.IsNullOrWhiteSpace(value)
                    ? value.Trim()
                    : null;
        }
    }
}
