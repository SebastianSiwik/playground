using BicycleService.Data.Sql.DAO;
using BicycleService.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Data.Sql
{
    public class BicycleServiceDbContext : DbContext
    {
        public BicycleServiceDbContext(DbContextOptions<BicycleServiceDbContext> options) : base(options) {}

        public virtual DbSet<DAO.User> User { get; set; }
        public virtual DbSet<Bicycle> Bicycle { get; set; }
        public virtual DbSet<Fault> Fault { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BicycleConfiguration());
            builder.ApplyConfiguration(new WorkshopConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new FaultConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        //}
    }
}
