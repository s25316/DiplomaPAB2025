// Ignore Spelling: Regon, Plugin, Pkd, Kod, Nazwa
using PkdResponse = RegonPlugin.Responses.Raporty.PKD.Pkd;
namespace RegonPlugin.Models
{
    public record Pkd
    {
        public string Kod { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public bool IsMain { get; init; } = false;
        public string? Silos { get; init; } = null;


        public static implicit operator Pkd(PkdResponse response) => Parse(response);
        public static Pkd Parse(PkdResponse response)
        {
            return new Pkd
            {
                Kod = response.Kod,
                Nazwa = response.Nazwa,
                IsMain = int.Parse(response.Przewazajace) > 0,
                Silos = response.Silos,
            };
        }
    }
}
