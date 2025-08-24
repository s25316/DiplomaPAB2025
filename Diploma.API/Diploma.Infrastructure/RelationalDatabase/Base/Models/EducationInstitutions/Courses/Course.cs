using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int NumberOfSemesters { get; set; }

        public int CourseNameId { get; set; }
        public virtual CourseName Name { get; set; } = null!;

        public string LanguageId { get; set; } = null!;
        public virtual CourseLanguage Language { get; set; } = null!;

        public int FormId { get; set; }
        public virtual CourseForm Form { get; set; } = null!;

        public int TitleId { get; set; }
        public virtual CourseTitle Title { get; set; } = null!;

        public int ProfileId { get; set; }
        public virtual CourseProfile Profile { get; set; } = null!;

        public int LevelId { get; set; }
        public virtual CourseLevel Level { get; set; } = null!;

        public virtual ICollection<DisciplineCourse> Disciplines { get; set; } = [];
        public virtual ICollection<EducationInstitutionCourse> Institutions { get; set; } = [];
        public virtual ICollection<PersonCourse> People { get; set; } = [];
    }
}
