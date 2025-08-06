// Ignore Spelling: Plugin, ects
// Ignore Spelling: Studia dualne to model kształcenia, który łączy naukę na uczelni z regularną pracą u konkretnego pracodawcy
// Ignore Spelling: Studia pomostowe to kierunek, który pozwala na uzupełnienie wykształcenia zawodowego o tytuł licencjata.
// Ignore Spelling: Czy studia we współpracy z organizacją zawodową? 
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public record CourseInstance
    {
        [JsonPropertyName("courseInstanceUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("courseInstanceCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Code { get; init; }

        [JsonPropertyName("courseInstanceOldCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? OldCode { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = null!;

        [JsonPropertyName("formCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int FormCode { get; init; }

        [JsonPropertyName("formName")]
        public string FormName { get; init; } = null!;

        [JsonPropertyName("titleCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int TitleCode { get; init; }

        [JsonPropertyName("titleName")]
        public string TitleName { get; init; } = null!;

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; init; } = null!;

        [JsonPropertyName("languageName")]
        public string LanguageName { get; init; } = null!;

        [JsonPropertyName("philologicalLanguages")]
        public IReadOnlyList<Language> PhilologicalLanguages { get; init; } = [];

        [JsonPropertyName("educationStartDate")]
        public DateOnly EducationStartDate { get; init; }

        [JsonPropertyName("liquidationDate")]
        public DateOnly? LiquidationDate { get; init; }

        [JsonPropertyName("statusCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int StatusCode { get; init; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; } = null!;

        [JsonPropertyName("numberOfSemesters")]
        [JsonConverter(typeof(IntegerConverter))]
        public int NumberOfSemesters { get; init; }

        [JsonPropertyName("ects")]
        [JsonConverter(typeof(IntegerConverter))]
        public int Ects { get; init; }

        /// <summary>
        /// Studia dualne to model kształcenia, który łączy naukę na uczelni z regularną pracą 
        /// </summary>
        [JsonPropertyName("dual")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool Dual { get; init; }

        /// <summary>
        /// Studia pomostowe to kierunek, który pozwala na uzupełnienie wykształcenia zawodowego o tytuł licencjata.
        /// </summary>
        [JsonPropertyName("bridging")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool Bridging { get; init; }

        /// <summary>
        /// Czy studia we współpracy z organizacją zawodową
        /// </summary>
        [JsonPropertyName("coopWithVocational")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool CoopWithVocational { get; init; }
    }
}
