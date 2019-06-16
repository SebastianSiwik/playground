using BicycleService.Data.Sql.DAO;
using System.Collections.Generic;

namespace BicycleService.Data.Sql.Migrations
{
    public class DatabaseSeed
    {
        private readonly BicycleServiceDbContext _context;

        public DatabaseSeed(BicycleServiceDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var listBuilder = new ListBuilder();

            var userList = listBuilder.BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();

            var bicycleList = listBuilder.BuildBicycleList(userList);
            _context.Bicycle.AddRange(bicycleList);
            _context.SaveChanges();

            var workshopList = listBuilder.BuildWorkshopList();
            _context.Workshop.AddRange(workshopList);
            _context.SaveChanges();

            var serviceList = listBuilder.BuildServiceList(userList);
            _context.Service.AddRange(serviceList);
            _context.SaveChanges();

            var faultList = listBuilder.BuildFaultList(bicycleList, serviceList);
            _context.Fault.AddRange(faultList);
            _context.SaveChanges();
            
        }
    }
}
