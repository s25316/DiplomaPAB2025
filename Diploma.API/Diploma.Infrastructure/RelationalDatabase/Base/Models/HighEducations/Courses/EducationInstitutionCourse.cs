namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class EducationInstitutionCourse
    {
        public Guid InstitutionCourseId { get; set; }
        public bool IsMainInstitution { get; set; }
        public DateOnly DateFrom { get; init; }
        public DateOnly? DateTo { get; init; }

        public Guid InstitutionId { get; set; }
        public virtual EducationInstitution Institution { get; set; } = null!;

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;
    }
}
