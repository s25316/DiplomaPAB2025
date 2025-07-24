using System.Text.Json.Serialization;

namespace RadonPlugin.Responses.Courses
{
    public class Course
    {
        [JsonPropertyName("courseUuid")]
        public Guid Id { get; init; }

        [JsonPropertyName("courseCode")]
        public string CourseCode { get; init; } = string.Empty;

        [JsonPropertyName("courseOldCode")]
        public string CourseOldCode { get; init; } = string.Empty;

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; } = string.Empty;

        [JsonPropertyName("levelCode")]
        public string LevelCode { get; init; } = string.Empty;

        [JsonPropertyName("levelName")]
        public string LevelName { get; init; } = string.Empty;

        [JsonPropertyName("profileCode")]
        public string ProfileCode { get; init; } = string.Empty;

        [JsonPropertyName("profileName")]
        public string ProfileName { get; init; } = string.Empty;

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; } = string.Empty;

        [JsonPropertyName("iscedName")]
        public string IscedName { get; init; } = string.Empty;

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; init; } = string.Empty;

        [JsonPropertyName("teacherTraining")]
        public string TeacherTraining { get; init; } = string.Empty;

        [JsonPropertyName("philological")]
        public string Philological { get; init; } = string.Empty;

        [JsonPropertyName("philologicalLanguages")]
        public IReadOnlyList<Language> PhilologicalLanguages { get; init; } = new List<Language>();

        [JsonPropertyName("coLed")]
        public string CoLed { get; init; } = string.Empty;

        [JsonPropertyName("coLedDataFrom")]
        public string CoLedDataFrom { get; init; } = string.Empty;

        [JsonPropertyName("coLedInterdisciplinary")]
        public string CoLedInterdisciplinary { get; init; } = string.Empty;

        [JsonPropertyName("currentStatusCode")]
        public string CurrentStatusCode { get; init; } = string.Empty; // Zgodnie z JSON jest to string "3"

        [JsonPropertyName("currentStatusName")]
        public string CurrentStatusName { get; init; } = string.Empty;

        [JsonPropertyName("terminationInitializationDate")]
        public string TerminationInitializationDate { get; init; } = string.Empty;

        [JsonPropertyName("liquidationDate")]
        public string LiquidationDate { get; init; } = string.Empty;

        [JsonPropertyName("disciplines")]
        public IReadOnlyList<Discipline> Disciplines { get; init; } = new List<Discipline>();

        [JsonPropertyName("leadingInstitutionUuid")]
        public string LeadingInstitutionUuid { get; init; } = string.Empty;

        [JsonPropertyName("leadingInstitutionName")]
        public string LeadingInstitutionName { get; init; } = string.Empty;

        [JsonPropertyName("leadingInstitutionIsForeign")]
        public string LeadingInstitutionIsForeign { get; init; } = string.Empty;

        [JsonPropertyName("leadingInstitutionCity")]
        public string LeadingInstitutionCity { get; init; } = string.Empty;

        [JsonPropertyName("leadingInstitutionVoivodeship")]
        public string LeadingInstitutionVoivodeship { get; init; } = string.Empty;

        [JsonPropertyName("leadingInstitutionVoivodeshipCode")]
        public string LeadingInstitutionVoivodeshipCode { get; init; } = string.Empty;

        [JsonPropertyName("mainInstitutionUuid")]
        public string MainInstitutionUuid { get; init; } = string.Empty;

        [JsonPropertyName("mainInstitutionName")]
        public string MainInstitutionName { get; init; } = string.Empty;

        [JsonPropertyName("mainInstitutionKind")]
        public string MainInstitutionKind { get; init; } = string.Empty;

        [JsonPropertyName("mainInstitutionKindCode")]
        public string MainInstitutionKindCode { get; init; } = string.Empty;

        [JsonPropertyName("supervisingInstitutionUuid")]
        public string SupervisingInstitutionUuid { get; init; } = string.Empty;

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; } = string.Empty;

        [JsonPropertyName("coLeadingInstitutions")]
        public IReadOnlyList<CoLeadingInstitutionDto> CoLeadingInstitutions { get; init; } = new List<CoLeadingInstitutionDto>();

        [JsonPropertyName("organizationalUnits")]
        public IReadOnlyList<OrganizationalUnit> OrganizationalUnits { get; init; } = new List<OrganizationalUnit>();

        [JsonPropertyName("legalBasisTypeCode")]
        public string LegalBasisTypeCode { get; init; } = string.Empty; // Zgodnie z JSON jest to string "2"

        [JsonPropertyName("legalBasisTypeName")]
        public string LegalBasisTypeName { get; init; } = string.Empty;

        [JsonPropertyName("legalBasisNumber")]
        public string LegalBasisNumber { get; init; } = string.Empty;

        [JsonPropertyName("legalBasisDate")]
        public string LegalBasisDate { get; init; } = string.Empty;

        [JsonPropertyName("courseInstances")]
        public IReadOnlyList<CourseInstance> CourseInstances { get; init; } = new List<CourseInstance>();

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; } = string.Empty;

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; } = string.Empty;
    }
}
