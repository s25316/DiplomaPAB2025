namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class CourseName
    {
        public int CourseNameId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = [];
    }
}
