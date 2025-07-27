// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.DoctoralSchools
{
    public class Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string DisciplineCode { get; init; } = null!;

        [JsonPropertyName("disciplineName")]
        public string DisciplineName { get; init; } = null!;
    }
}
