using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.People
{
    public class PersonCourse
    {
        public Guid PersonCourseId { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }


        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
    }
}
