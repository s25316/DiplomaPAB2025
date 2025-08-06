// Ignore Spelling: Plugin, Isced, Uuid, Voivodeship
using RadonPlugin.Converters;
using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.NonDictionaries.Courses
{
    public class Course
    {
        [JsonPropertyName("courseUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("courseCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int CourseCode { get; init; }

        [JsonPropertyName("courseOldCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? CourseOldCode { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = null!;

        [JsonPropertyName("levelCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int LevelCode { get; init; }

        [JsonPropertyName("levelName")]
        public string LevelName { get; init; } = null!;

        [JsonPropertyName("profileCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int ProfileCode { get; init; }

        [JsonPropertyName("profileName")]
        public string ProfileName { get; init; } = null!;

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; } = null!;

        [JsonPropertyName("iscedName")]
        public string IscedName { get; init; } = null!;

        [JsonPropertyName("creationDate")]
        public DateOnly? CreationDate { get; init; }

        [JsonPropertyName("terminationInitializationDate")]
        public DateOnly? TerminationInitializationDate { get; init; }

        [JsonPropertyName("liquidationDate")]
        public DateOnly? LiquidationDate { get; init; }

        [JsonPropertyName("teacherTraining")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool TeacherTraining { get; init; }

        [JsonPropertyName("philological")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool Philological { get; init; }

        [JsonPropertyName("coLed")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool CoLed { get; init; }

        [JsonPropertyName("philologicalLanguages")]
        public IReadOnlyList<Language> PhilologicalLanguages { get; init; } = new List<Language>();

        [JsonPropertyName("coLedDataFrom")]
        public string CoLedDataFrom { get; init; } = string.Empty; // ?? Dateonly? ""

        [JsonPropertyName("coLedInterdisciplinary")]
        public string CoLedInterdisciplinary { get; init; } = string.Empty; // ?? Tak/Nie

        [JsonPropertyName("currentStatusCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int CurrentStatusCode { get; init; }

        [JsonPropertyName("currentStatusName")]
        public string CurrentStatusName { get; init; } = null!;

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<Discipline> Disciplines { get; init; } = new List<Discipline>();

        [JsonPropertyName("leadingInstitutionUuid")]
        public Guid LeadingInstitutionUuid { get; init; }

        [JsonPropertyName("leadingInstitutionName")]
        public string LeadingInstitutionName { get; init; } = null!;

        [JsonPropertyName("leadingInstitutionIsForeign")]
        [JsonConverter(typeof(PolishBoolConverter))]
        public bool LeadingInstitutionIsForeign { get; init; }

        [JsonPropertyName("leadingInstitutionCity")]
        public string LeadingInstitutionCity { get; init; } = null!;

        [JsonPropertyName("leadingInstitutionVoivodeship")]
        public string LeadingInstitutionVoivodeship { get; init; } = null!;

        [JsonPropertyName("leadingInstitutionVoivodeshipCode")]
        [JsonConverter(typeof(IntegerNullConverter))]
        public int? LeadingInstitutionVoivodeshipCode { get; init; }

        [JsonPropertyName("mainInstitutionUuid")]
        public Guid MainInstitutionUuid { get; init; }

        [JsonPropertyName("mainInstitutionName")]
        public string MainInstitutionName { get; init; } = null!;

        [JsonPropertyName("mainInstitutionKindCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int MainInstitutionKindCode { get; init; }

        [JsonPropertyName("mainInstitutionKind")]
        public string MainInstitutionKind { get; init; } = null!;

        [JsonPropertyName("supervisingInstitutionUuid")]
        public Guid SupervisingInstitutionUuid { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; } = null!;

        [JsonPropertyName("coLeadingInstitutions")]
        public IReadOnlyList<CoLeadingInstitution> CoLeadingInstitutions { get; init; } = new List<CoLeadingInstitution>();

        [JsonPropertyName("organizationalUnits")]
        public IReadOnlyList<OrganizationalUnit> OrganizationalUnits { get; init; } = new List<OrganizationalUnit>();

        [JsonPropertyName("legalBasisTypeCode")]
        [JsonConverter(typeof(IntegerConverter))]
        public int LegalBasisTypeCode { get; init; }

        [JsonPropertyName("legalBasisTypeName")]
        public string LegalBasisTypeName { get; init; } = null!;

        [JsonPropertyName("legalBasisNumber")]
        public string LegalBasisNumber { get; init; } = null!;

        [JsonPropertyName("legalBasisDate")]
        public DateOnly? LegalBasisDate { get; init; }

        [JsonPropertyName("courseInstances")]
        public IReadOnlyList<CourseInstance> CourseInstances { get; init; } = new List<CourseInstance>();

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = string.Empty;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = string.Empty;
    }
}
