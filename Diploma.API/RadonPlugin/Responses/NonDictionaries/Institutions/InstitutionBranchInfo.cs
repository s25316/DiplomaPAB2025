// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Institutions
{
    public record InstitutionBranchInfo
    {
        [JsonPropertyName("branchUuid")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("branchName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("branchCity")]
        public string City { get; init; } = null!;
    }
}
