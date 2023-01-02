using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestForBart.Core.Entities;

namespace TestForBart.Persistence.EntityConfigurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(incident => incident.Name);
            builder.Property(incident => incident.Name)
                .HasDefaultValueSql("'Incident_'+convert(varchar,getdate(),25)")
                .ValueGeneratedOnAdd();
        }
    }
}
