// iGnore spelling: Plugin, Uuid, Regon, Krs, www, Voivodeship
using RadonPlugin.Converters;
using RadonPlugin.Responses.Shared;
using RadonPlugin.Responses.Shared.NameStamps;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Branches
{
    public record Branch
    {
        [JsonPropertyName("branchUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("mainInstitutionUuid")]
        public Guid MainInstitutionUuid { get; init; }

        [JsonPropertyName("mainInstitutionName")]
        public string MainInstitutionName { get; init; } = null!;

        [JsonPropertyName("creationDate")]
        public DateOnly CreationDate { get; init; }

        [JsonPropertyName("liquidationStartDate")]
        public DateOnly? LiquidationStartDate { get; init; }

        [JsonPropertyName("liquidationDate")]
        public DateOnly? LiquidationDate { get; init; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; init; } = null!;

        [JsonPropertyName("status")]
        public string Status { get; init; } = null!;

        [JsonPropertyName("regon")]
        public string? Regon { get; init; } = null;

        [JsonPropertyName("nip")]
        public string? Nip { get; init; } = null;

        [JsonPropertyName("krs")]
        public string? Krs { get; init; } = null;

        [JsonPropertyName("www")]
        public string? Www { get; init; }

        [JsonPropertyName("eMail")]
        public string? Email { get; init; }

        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        [JsonPropertyName("countryCd")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? CountryCode { get; init; }

        [JsonPropertyName("country")]
        public string? Country { get; init; }

        [JsonPropertyName("voivodeshipCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? VoivodeshipCode { get; init; }

        [JsonPropertyName("voivodeship")]
        public string? Voivodeship { get; init; } = null;

        [JsonPropertyName("city")]
        public string City { get; init; } = null!;

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; init; } = null!;

        [JsonPropertyName("street")]
        public string? Street { get; init; }

        [JsonPropertyName("buildingNumber")]
        public string BuildingNumber { get; init; } = null!;

        [JsonPropertyName("apartmentNumber")]
        public string? ApartmentNumber { get; init; }

        [JsonPropertyName("espAddress")]
        public string? EspAddress { get; init; }

        [JsonPropertyName("names")]
        public IReadOnlyList<NameStamp> Names { get; init; } = [];

        [JsonPropertyName("statuses")]
        public IReadOnlyList<NameStamp> Statuses { get; init; } = [];

        [JsonPropertyName("addresses")]
        public IReadOnlyList<AddressStamp> Addresses { get; init; } = [];

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = null!;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = null!;
    }
}
