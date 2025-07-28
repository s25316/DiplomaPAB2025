// Ignore Spelling: Plugin, Uuid
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.SpecializedEducations
{
    public class SpecializedEducation
    {
        [JsonPropertyName("specializedEducationUuid")]
        public Guid Uuid { get; init; }

        [JsonPropertyName("specializedEducationName")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("certificateCode")]
        public int CertificateCode { get; init; }

        [JsonPropertyName("certificateName")]
        public string CertificateName { get; init; } = null!;

        [JsonPropertyName("semesterStart")]
        public string SemesterStart { get; init; } = null!;

        [JsonPropertyName("institutionUuid")]
        public Guid InstitutionUuid { get; init; }

        [JsonPropertyName("institutionName")]
        public string InstitutionName { get; init; } = null!;

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = null!;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = null!;
    }
}
