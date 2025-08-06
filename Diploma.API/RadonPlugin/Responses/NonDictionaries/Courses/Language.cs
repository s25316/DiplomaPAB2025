// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public record Language
    {
        [JsonPropertyName("languageCode")]
        public string Code { get; init; } = null!;

        [JsonPropertyName("languageName")]
        public string Name { get; init; } = null!;
    }
}
