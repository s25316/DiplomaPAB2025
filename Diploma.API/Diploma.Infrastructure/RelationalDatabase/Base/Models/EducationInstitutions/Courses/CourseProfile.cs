namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses
{
    public class CourseProfile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = [];
    }
}
