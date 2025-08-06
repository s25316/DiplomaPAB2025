// Ignore Spelling: Plugin
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public record Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string Code { get; init; } = null!;

        [JsonPropertyName("disciplineName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("disciplinePercentageShare")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Percentage { get; init; }

        [JsonPropertyName("disciplineLeading")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool? DisciplineLeading { get; init; }
    }
}
