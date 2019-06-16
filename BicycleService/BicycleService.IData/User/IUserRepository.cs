using System.Threading.Tasks;

namespace BicycleService.IData.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(Domain.User.User user);
    }
}
