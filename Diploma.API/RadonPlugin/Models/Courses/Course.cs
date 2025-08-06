// Ignore Spelling: Plugin, Ects, Isced
using RadonPlugin.Models.Shared;
using RadonPlugin.Responses.NonDictionaries.Courses;
using CourseResponse = RadonPlugin.Responses.NonDictionaries.Courses.Course;

namespace RadonPlugin.Models.Courses
{
    public record Course
    {
        public Pair<Guid> LeadingInstitution { get; init; } = null!;
        public Pair<Guid> MainInstitution { get; init; } = null!;
        public Guid Id { get; init; }
        public int Code { get; init; }
        public int? OldCode { get; init; }
        public string CourseName { get; init; } = null!;
        public int Ects { get; init; }
        public int NumberOfSemesters { get; init; }
        public DateOnly EducationStartDate { get; init; }
        public DateOnly? LiquidationDate { get; init; }
        public Pair<int> Profile { get; init; } = null!;
        public Pair<int> Form { get; init; } = null!;
        public Pair<int> Title { get; init; } = null!;
        public Pair<int> Level { get; init; } = null!;
        public Pair<int> Status { get; init; } = null!;
        public Pair<string> Isced { get; init; } = null!;
        public Pair<string> Language { get; init; } = null!;
        public bool IsDual { get; init; }
        public bool IsBridging { get; init; }
        public bool IsCoopWithVocational { get; init; }
        public bool IsPhilological { get; init; }
        public bool IsTeacherFinally { get; init; }
        public IReadOnlyList<Language> PhilologicalLanguages { get; init; } = [];
        public IReadOnlyList<Discipline> Disciplines { get; init; } = [];
        public IReadOnlyList<OrganizationalUnit> OrganizationalUnits { get; init; } = [];
        public IReadOnlyList<CoLeadingInstitution> CoLeadingInstitutions { get; init; } = [];


        public static IEnumerable<Course> Parse(CourseResponse response)
        {
            var level = new Pair<int>
            {
                Id = response.LevelCode,
                Name = response.LevelName,
            };
            var profile = new Pair<int>
            {
                Id = response.ProfileCode,
                Name = response.ProfileName,
            };
            var isced = new Pair<string>
            {
                Id = response.IscedCode,
                Name = response.IscedName,
            };
            var leadingInstitution = new Pair<Guid>
            {
                Id = response.LeadingInstitutionUuid,
                Name = response.LeadingInstitutionName,
            };
            var mainInstitution = new Pair<Guid>
            {
                Id = response.MainInstitutionUuid,
                Name = response.MainInstitutionName,
            };

            return response.CourseInstances
                .Select(item => new Course
                {
                    Id = item.Id,
                    Code = item.Code,
                    OldCode = item.OldCode,
                    CourseName = item.CourseName,
                    Ects = item.Ects,
                    NumberOfSemesters = item.NumberOfSemesters,
                    EducationStartDate = item.EducationStartDate,
                    LiquidationDate = item.LiquidationDate,

                    IsDual = item.Dual,
                    IsBridging = item.Bridging,
                    IsCoopWithVocational = item.CoopWithVocational,
                    IsPhilological = response.Philological,
                    IsTeacherFinally = response.TeacherTraining,

                    Form = new Pair<int>
                    {
                        Id = item.FormCode,
                        Name = item.FormName,
                    },
                    Title = new Pair<int>
                    {
                        Id = item.TitleCode,
                        Name = item.TitleName,
                    },
                    Status = new Pair<int>
                    {
                        Id = item.StatusCode,
                        Name = item.StatusName,
                    },
                    Language = new Pair<string>
                    {
                        Id = item.LanguageCode,
                        Name = item.LanguageName,
                    },
                    Level = level,
                    Profile = profile,
                    Isced = isced,
                    MainInstitution = mainInstitution,
                    LeadingInstitution = leadingInstitution,

                    PhilologicalLanguages = item.PhilologicalLanguages,
                    Disciplines = response.Disciplines,
                    OrganizationalUnits = response.OrganizationalUnits,
                    CoLeadingInstitutions = response.CoLeadingInstitutions,
                });
        }
    }
}
