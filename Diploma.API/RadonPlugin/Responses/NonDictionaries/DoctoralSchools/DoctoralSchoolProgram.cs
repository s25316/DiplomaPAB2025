// Ignore Spelling: Plugin, Uuid, Isced
using RadonPlugin.Responses.Shared.InstitutionInfos;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.DoctoralSchools
{
    public class DoctoralSchoolProgram
    {
        [JsonPropertyName("programUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("programName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("programScope")]
        public string? ProgramScope { get; init; }

        [JsonPropertyName("educationStartDate")]
        public DateOnly EducationStartDate { get; init; }

        [JsonPropertyName("educationEndDate")]
        public DateOnly? EducationEndDate { get; init; }

        [JsonPropertyName("numberOfSemesters")]
        public int NumberOfSemesters { get; init; }

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; } = null!;

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<DoctoralSchoolDiscipline> Disciplines { get; init; } = [];

        [JsonPropertyName("cooperatingInstitutions")]
        public IReadOnlyList<InstitutionInfo> CooperatingInstitutions { get; init; } = [];
    }
}
