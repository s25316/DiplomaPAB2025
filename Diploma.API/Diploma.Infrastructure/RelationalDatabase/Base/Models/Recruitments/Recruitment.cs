using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Recruitments
{
    public class Recruitment
    {
        public Guid RecruitmentId { get; set; }

        public Guid ProjectPositionId { get; set; }
        public virtual ProjectPosition Position { get; set; } = null!;

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
    }
}
