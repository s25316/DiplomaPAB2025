// Ignore Spelling: Plugin, Uuid, Fos
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public record CoLeadingInstitution
    {
        [JsonPropertyName("coLeadingInstitutionUuid")]
        public Guid? Uuid { get; init; }

        [JsonPropertyName("coLeadingInstitutionName")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("isForeign")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool IsForeign { get; init; }

        [JsonPropertyName("courseUuid")]
        public Guid? CourseUuid { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = string.Empty;

        [JsonPropertyName("dateFrom")]
        public DateOnly DateFrom { get; init; }

        [JsonPropertyName("dateTo")]
        public DateOnly? DateTo { get; init; }

        [JsonPropertyName("coLedFosConfirmationStatus")]
        public string CoLedFosConfirmationStatus { get; init; } = null!;
    }
}
