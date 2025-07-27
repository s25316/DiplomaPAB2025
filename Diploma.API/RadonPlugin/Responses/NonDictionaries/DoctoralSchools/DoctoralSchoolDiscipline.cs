// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.DoctoralSchools
{
    public class DoctoralSchoolDiscipline
    {
        [JsonPropertyName("disciplineCode")]
        public string DisciplineCode { get; init; } = null!;

        [JsonPropertyName("disciplineName")]
        public string DisciplineName { get; init; } = null!;
    }
}
