using BicycleService.Api.ViewModels;

namespace BicycleService.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                Address = user.Address,
                RegistrationDate = user.RegistrationDate,
                BirthDate = user.BirthDate,
                IsBannedUser = user.IsBannedUser,
                UserStatus = user.UserStatus
            };
            return userViewModel;
        }
    }
}
