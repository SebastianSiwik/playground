using BicycleService.IServices.Requests;
using System.Threading.Tasks;

namespace BicycleService.IServices.User
{
    public interface IUserService
    {
        Task<Domain.User.User> CreateUser(CreateUser createUser);
    }
}
