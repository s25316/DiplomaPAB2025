using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.SpecializedEducations
{
    public class SpecializedEducation
    {
        [JsonPropertyName("specializedEducationUuid")]
        public string SpecializedEducationUuid { get; init; }

        [JsonPropertyName("specializedEducationName")]
        public string SpecializedEducationName { get; init; }

        [JsonPropertyName("certificateCode")]
        public string CertificateCode { get; init; }

        [JsonPropertyName("certificateName")]
        public string CertificateName { get; init; }

        [JsonPropertyName("semesterStart")]
        public string SemesterStart { get; init; }

        [JsonPropertyName("institutionUuid")]
        public string InstitutionUuid { get; init; }

        [JsonPropertyName("institutionName")]
        public string InstitutionName { get; init; }

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
