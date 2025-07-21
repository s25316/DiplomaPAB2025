// Ignore Spelling: Regon, Plugin
// Ignore Spelling: Raport, Jednostki, Pkd
namespace RegonPlugin.Models.DTOs
{
    public class RaportJednostkiWithPkd
    {
        public RaportJednostki RaportJednostki { get; init; } = null!;
        public IEnumerable<Pkd> Pkd { get; init; } = [];
    }
}
