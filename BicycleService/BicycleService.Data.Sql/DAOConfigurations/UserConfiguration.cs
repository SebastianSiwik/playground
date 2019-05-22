using BicycleService.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleService.Data.Sql.DAOConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.UserEmail).IsRequired();
            builder.Property(c => c.IsBannedUser).HasColumnType("tinyint(1)");
            builder.ToTable("User");
        }
    }
}
