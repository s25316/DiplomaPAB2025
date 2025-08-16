namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class CourseForm
    {
        public int FormId { get; set; }
        public string NamePl { get; set; } = null!;
        public string NameEn { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
