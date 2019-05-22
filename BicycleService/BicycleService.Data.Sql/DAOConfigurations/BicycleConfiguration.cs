using BicycleService.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleService.Data.Sql.DAOConfigurations
{
    public class BicycleConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Bicycles)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("Bicycle");
        }
    }
}
