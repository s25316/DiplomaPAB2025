// ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Dictionaries
{
    public class DictionaryStringData
    {
        [JsonPropertyName("namePl")]
        public string NamePl { get; init; } = null!;

        [JsonPropertyName("nameEn")]
        public string NameEn { get; init; } = null!;

        [JsonPropertyName("code")]
        public string Code { get; init; } = null!;
    }
}
