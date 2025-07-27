// Ignore Spelling: Plugin
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public class CourseInstance
    {
        [JsonPropertyName("courseInstanceUuid")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("courseInstanceCode")]
        public string CourseInstanceCode { get; init; } = string.Empty;

        [JsonPropertyName("courseInstanceOldCode")]
        public string CourseInstanceOldCode { get; init; } = string.Empty;

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = string.Empty;

        [JsonPropertyName("formCode")]
        public string FormCode { get; init; } = string.Empty;

        [JsonPropertyName("formName")]
        public string FormName { get; init; } = string.Empty;

        [JsonPropertyName("titleCode")]
        public string TitleCode { get; init; } = string.Empty;

        [JsonPropertyName("titleName")]
        public string TitleName { get; init; } = string.Empty;

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; init; } = string.Empty;

        [JsonPropertyName("languageName")]
        public string LanguageName { get; init; } = string.Empty;

        [JsonPropertyName("philologicalLanguages")]
        public IReadOnlyList<Language> PhilologicalLanguages { get; init; } = new List<Language>();

        [JsonPropertyName("educationStartDate")]
        public string EducationStartDate { get; init; } = string.Empty;

        [JsonPropertyName("numberOfSemesters")]
        public string NumberOfSemesters { get; init; } = string.Empty;

        [JsonPropertyName("ects")]
        public string Ects { get; init; } = string.Empty;

        [JsonPropertyName("dual")]
        public string Dual { get; init; } = string.Empty;

        [JsonPropertyName("bridging")]
        public string Bridging { get; init; } = string.Empty;

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; init; } = string.Empty; // Zgodnie z JSON jest to string "3"

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; } = string.Empty;

        [JsonPropertyName("liquidationDate")]
        public string LiquidationDate { get; init; } = string.Empty;

        [JsonPropertyName("coopWithVocational")]
        public string CoopWithVocational { get; init; } = string.Empty;
    }
}
