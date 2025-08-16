namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class CourseForm
    {
        public int FormId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
