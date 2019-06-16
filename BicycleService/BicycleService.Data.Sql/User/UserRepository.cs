using BicycleService.IData.User;
using System.Threading.Tasks;

namespace BicycleService.Data.Sql.User
{
    class UserRepository: IUserRepository
    {
        private readonly BicycleServiceDbContext _context;

        public UserRepository(BicycleServiceDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO = new DAO.User
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                Address = user.Address,
                RegistrationDate = user.RegistrationDate,
                BirthDate = user.BirthDate,
                IsBannedUser = user.IsBannedUser,
                UserStatus = user.UserStatus
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }
    }
}
