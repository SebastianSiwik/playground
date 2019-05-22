using BicycleService.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleService.Data.Sql.DAOConfigurations
{
    public class FaultConfiguration : IEntityTypeConfiguration<Fault>
    {
        public void Configure(EntityTypeBuilder<Fault> builder)
        {
            builder.Property(c => c.FaultDescription).IsRequired();
            builder.HasOne(x => x.Bicycle)
                .WithMany(x => x.Faults)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.BicycleId);
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Faults)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ServiceId);
            builder.ToTable("Fault");
        }
    }
}
