// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.DoctoralSchools
{
    public class DoctoralSchoolDiscipline
    {
        [JsonPropertyName("disciplineCode")]
        public string Code { get; init; } = null!;

        [JsonPropertyName("disciplineName")]
        public string Name { get; init; } = null!;
    }
}
