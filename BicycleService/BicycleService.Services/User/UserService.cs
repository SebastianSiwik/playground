using BicycleService.IData.User;
using BicycleService.IServices.Requests;
using BicycleService.IServices.User;
using System.Threading.Tasks;

namespace BicycleService.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new Domain.User.User(createUser.UserName, createUser.Email, createUser.BirthDate);
            user.UserId = await _userRepository.AddUser(user);
            return user;
        }
    }
}
