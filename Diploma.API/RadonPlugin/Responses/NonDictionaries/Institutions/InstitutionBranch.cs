// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Institutions
{
    public record InstitutionBranch
    {
        [JsonPropertyName("branchUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("branchName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("branchCity")]
        public string City { get; init; } = null!;
    }
}
