namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses
{
    public class DisciplineCourse
    {
        public Guid DisciplineCourseId { get; set; }
        public bool IsMain { get; set; }

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

        public string DisciplineId { get; set; } = null!;
        public virtual Discipline Discipline { get; set; } = null!;
    }
}
