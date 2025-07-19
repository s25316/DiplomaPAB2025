// Ignore Spelling: Regon, Plugin, Numer, Telefonu, Wewnetrzny, Faksu
using RaportJednostkiResponse = RegonPlugin.Responses.Raporty.Jednostki.RaportJednostki;

namespace RegonPlugin.Models.DTOs
{
    public record Contacts
    {
        // Properties
        public IEnumerable<string> NumerTelefonu { get; init; } = [];
        public IEnumerable<string> NumerWewnetrznyTelefonu { get; init; } = [];
        public IEnumerable<string> NumerFaksu { get; init; } = [];
        public IEnumerable<string> Email { get; init; } = [];
        public IEnumerable<string> WWW { get; init; } = [];


        public static implicit operator Contacts?(RaportJednostkiResponse response) => Parse(response);
        public static Contacts? Parse(RaportJednostkiResponse response)
        {
            var contacts = new Contacts
            {
                NumerTelefonu = response
                    .NumerTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerWewnetrznyTelefonu = response
                    .NumerWewnetrznyTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerFaksu = response
                    .NumerFaksu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                Email = response
                    .AdresEmail
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                WWW = response
                    .WWW
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
            };

            if (contacts.NumerTelefonu.Any() ||
                contacts.NumerWewnetrznyTelefonu.Any() ||
                contacts.NumerFaksu.Any() ||
                contacts.Email.Any() ||
                contacts.WWW.Any())
            {
                return contacts;
            }

            return null;
        }
    }
}
