using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Courses
{
    public class CoLeadingInstitutionDto
    {
        [JsonPropertyName("coLeadingInstitutionUuid")]
        public string CoLeadingInstitutionUuid { get; init; } = string.Empty;

        [JsonPropertyName("coLeadingInstitutionName")]
        public string CoLeadingInstitutionName { get; init; } = string.Empty;

        [JsonPropertyName("isForeign")]
        public string IsForeign { get; init; } = string.Empty;

        [JsonPropertyName("courseUuid")]
        public string CourseUuid { get; init; } = string.Empty;

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = string.Empty;

        [JsonPropertyName("dateFrom")]
        public DateOnly DateFrom { get; init; }

        [JsonPropertyName("dateTo")]
        public DateOnly? DateTo { get; init; }

        [JsonPropertyName("coLedFosConfirmationStatus")]
        public string CoLedFosConfirmationStatus { get; init; } = string.Empty;
    }
}
