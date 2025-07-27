// Ignore Spelling: Plugin, Uuid
using RadonPlugin.Responses.Shared.InstitutionInfos;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.DoctoralSchools
{
    public class DoctoralSchoolProgram
    {
        [JsonPropertyName("programUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("programName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("programScope")]
        public string ProgramScope { get; init; }

        [JsonPropertyName("educationStartDate")]
        public string EducationStartDate { get; init; }

        [JsonPropertyName("numberOfSemesters")]
        public string NumberOfSemesters { get; init; }

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; }

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<Discipline> Disciplines { get; init; } = [];

        [JsonPropertyName("educationEndDate")]
        public string EducationEndDate { get; init; }

        [JsonPropertyName("cooperatingInstitutions")]
        public IReadOnlyList<InstitutionInfo> CooperatingInstitutions { get; init; } = [];
    }
}
