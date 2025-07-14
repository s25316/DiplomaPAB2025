// ignore Spelling: REGON, Pkd
namespace REGON.Models
{
    public class BaseCompanyData
    {
        public required RequestResult Status { get; init; }
        public FullReport Report { get; init; } = null!;
        public IEnumerable<Pkd> Pkd { get; init; } = [];
        public string Message { get; init; } = string.Empty;
    }
}
