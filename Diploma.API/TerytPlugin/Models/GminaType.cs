
// Ignore Spelling: Teryt, Plugin, Gmina
// Ignore Spelling: miejska, miejsko, wiejska, miasto, gminie, wiejskiej, obszar, wiejski
// Ignore Spelling: dzielnica, Warszawa, delegatura, miasta
namespace TerytPlugin.Models
{
    public record GminaType(int Id, string Name)
    {
        public static GminaType Miejska => new GminaType(1, "gmina miejska");
        public static GminaType Wiejska => new GminaType(2, "gmina wiejska");
        public static GminaType MiejskoWiejska => new GminaType(3, "gmina miejsko-wiejska");
        public static GminaType MiastoWMiejskoWiejskiej => new GminaType(4, "miasto w gminie miejsko-wiejskiej");
        public static GminaType ObszarWiejskiWMiejskoWiejskiej => new GminaType(5, "obszar wiejski w gminie miejsko-wiejskiej");
        public static GminaType Dzielnica => new GminaType(8, "dzielnica w m.st. Warszawa");
        public static GminaType Delegatura => new GminaType(9, "delegatura miasta");
        public static Dictionary<int, GminaType> Types => new Dictionary<int, GminaType>()
        {
            { 1, Miejska},
            { 2, Wiejska},
            { 3, MiejskoWiejska},
            { 4, MiastoWMiejskoWiejskiej},
            { 5, ObszarWiejskiWMiejskoWiejskiej},
            { 8, Dzielnica},
            { 9, Delegatura},
        };



        public static implicit operator GminaType?(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            if (
                !int.TryParse(value, out var id) ||
                !Types.TryGetValue(id, out var type)
                )
            {
                throw new NotImplementedException(value);
            }

            return type;
        }
    }
}
