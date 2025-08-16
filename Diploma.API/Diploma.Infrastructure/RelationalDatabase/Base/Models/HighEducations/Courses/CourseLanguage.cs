namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class CourseLanguage
    {
        public string LanguageId { get; set; } = null!;
        public string NamePl { get; set; } = null!;
        public string NameEn { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
