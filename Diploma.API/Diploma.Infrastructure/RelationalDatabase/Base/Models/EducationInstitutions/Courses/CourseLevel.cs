namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses
{
    public class CourseLevel
    {
        public int LevelId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = [];
    }
}
