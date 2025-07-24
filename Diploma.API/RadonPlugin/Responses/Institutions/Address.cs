// Ignore Spelling: Plugin, Voivodeship
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Institutions
{
    public class Address
    {
        [JsonPropertyName("country")]
        public string Country { get; init; } = null!;

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; init; } = null!;

        [JsonPropertyName("city")]
        public string City { get; init; } = null!;

        [JsonPropertyName("postalCd")]
        public string PostalCode { get; init; } = null!;

        [JsonPropertyName("street")]
        public string? Street { get; init; }

        [JsonPropertyName("bNumber")]
        public string HouseNumber { get; init; } = null!;

        [JsonPropertyName("lNumber")]
        public string? FlatNumber { get; init; }

        [JsonPropertyName("dateFrom")]
        public DateOnly DateFrom { get; init; }
    }
}
