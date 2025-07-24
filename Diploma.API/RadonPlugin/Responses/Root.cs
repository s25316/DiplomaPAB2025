// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses
{
    public record Root<T>
    {
        [JsonPropertyName("results")]
        public List<T> Results { get; init; } = [];

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; init; } = null!;
    }
}
