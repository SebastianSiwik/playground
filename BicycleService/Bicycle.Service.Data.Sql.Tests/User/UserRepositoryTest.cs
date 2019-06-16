using BicycleService.Data.Sql;
using BicycleService.Data.Sql.User;
using BicycleService.IData.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BicycleService.Data.Sql.Tests
{
    public class UserRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private readonly BicycleServiceDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BicycleServiceDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=bicycledb;pwd=bicycledb;port=3306;Database=bicycle_service_db");
            _context = new BicycleServiceDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task AddUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email", DateTime.UtcNow);

            var userId = await _userRepository.AddUser(user);

            var createdUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(createdUser);

            _context.User.Remove(createdUser);
            await _context.SaveChangesAsync();
        }
    }
}
