using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Guid OwnerId { get; set; }
        public virtual Person Owner { get; set; } = null!;

        public virtual ICollection<ProjectPosition> Positions { get; set; } = [];
    }
}
