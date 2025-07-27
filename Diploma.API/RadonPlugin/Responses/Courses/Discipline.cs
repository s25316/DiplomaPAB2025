// Ignore Spelling: Plugin
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Courses
{
    public class Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string DisciplineCode { get; init; } = string.Empty;

        [JsonPropertyName("disciplineName")]
        public string DisciplineName { get; init; } = string.Empty;

        [JsonPropertyName("disciplinePercentageShare")]
        public string Percentage { get; init; }

        [JsonPropertyName("disciplineLeading")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool? DisciplineLeading { get; init; }
    }
}
