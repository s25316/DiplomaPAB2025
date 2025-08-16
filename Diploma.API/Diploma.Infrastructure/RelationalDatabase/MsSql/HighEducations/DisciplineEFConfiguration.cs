using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations
{
    public class DisciplineEFConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(nameof(Discipline));
            builder.HasKey(x => x.DisciplineId).HasName($"{nameof(Discipline)}_pk");
        }
    }
}
