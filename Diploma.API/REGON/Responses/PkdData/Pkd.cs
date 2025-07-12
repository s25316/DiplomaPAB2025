// Ignore Spelling: REGON, Pkd, Kod, Nazwa, Przewazajace
namespace REGON.Responses.PkdData
{
    public class Pkd
    {
        // Properties
        public string Kod { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public bool IsMain { get; init; } = false;


        // Methods
        public static implicit operator Pkd(PkdResponse res)
        {
            return new Pkd
            {
                Kod = res.Kod,
                Nazwa = res.Nazwa,
                IsMain = int.Parse(res.Przewazajace) > 0,
            };
        }
    }
}
