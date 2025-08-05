// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Institutions
{
    public record InstitutionFederation
    {
        [JsonPropertyName("institutionUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("institutionName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public DateOnly DateFrom { get; init; }

        [JsonPropertyName("dateTo")]
        public DateOnly? DateTo { get; init; }
    }
}
