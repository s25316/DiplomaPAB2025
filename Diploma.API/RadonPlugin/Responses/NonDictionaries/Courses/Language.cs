// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public class Language
    {
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; init; } = null!;

        [JsonPropertyName("languageName")]
        public string LanguageName { get; init; } = null!;
    }
}
