// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Dictionaries
{
    public class DictionaryGuidData
    {
        [JsonPropertyName("namePl")]
        public string NamePl { get; init; } = null!;

        [JsonPropertyName("nameEn")]
        public string NameEn { get; init; } = null!;

        [JsonPropertyName("code")]
        public Guid Code { get; init; }
    }
}
