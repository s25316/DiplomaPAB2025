// Ignore Spelling: REGON, Numer, Telefonu, Wewnetrzny, Faksu, Adres
using REGON.Responses.FullData;

namespace REGON.Models.DTOs
{
    public class Contacts
    {
        // Properties
        public IEnumerable<string> NumerTelefonu { get; init; } = [];
        public IEnumerable<string> NumerWewnetrznyTelefonu { get; init; } = [];
        public IEnumerable<string> NumerFaksu { get; init; } = [];
        public IEnumerable<string> AdresEmail { get; init; } = [];
        public IEnumerable<string> WWW { get; init; } = [];


        // Methods
        public static Contacts? Parse(FullDataResponse res)
        {
            var contacts = new Contacts
            {
                NumerTelefonu = res
                    .NumerTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerWewnetrznyTelefonu = res
                    .NumerWewnetrznyTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerFaksu = res
                    .NumerFaksu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                AdresEmail = res
                    .AdresEmail
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                WWW = res
                    .WWW
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
            };

            if (contacts.NumerTelefonu.Any() ||
                contacts.NumerWewnetrznyTelefonu.Any() ||
                contacts.NumerFaksu.Any() ||
                contacts.AdresEmail.Any() ||
                contacts.WWW.Any())
            {
                return contacts;
            }
            return null;
        }
    }
}
