using BicycleService.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleService.Data.Sql.DAOConfigurations
{
    public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.Property(c => c.Address).IsRequired();
            builder.ToTable("Workshop");
        }
    }
}
