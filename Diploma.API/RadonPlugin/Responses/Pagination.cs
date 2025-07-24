// Ignore Spelling: Radon, Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses
{
    public record Pagination
    {
        [JsonPropertyName("maxCount")]
        public int MaxCount { get; init; }

        [JsonPropertyName("token")]
        public string Token { get; init; } = null!;
    }
}
