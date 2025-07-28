// Ignore Spelling: Plugin
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Dictionaries
{
    public class DictionaryIntData
    {
        [JsonPropertyName("namePl")]
        public string NamePl { get; init; } = null!;

        [JsonPropertyName("nameEn")]
        public string NameEn { get; init; } = null!;

        [JsonPropertyName("code")]
        [JsonConverter(typeof(StringIntConverter))]
        public int Code { get; init; }
    }
}
