using BicycleService.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BicycleService.Data.Sql.DAOConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(c => c.Price).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.Services)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Workshop)
                .WithMany(x => x.Services)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.WorkshopId);
            builder.ToTable("Service");
        }
    }
}
