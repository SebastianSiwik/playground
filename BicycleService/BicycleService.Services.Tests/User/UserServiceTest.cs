using BicycleService.Domain.DomainExceptions;
using BicycleService.IData.User;
using BicycleService.IServices.Requests;
using BicycleService.IServices.User;
using BicycleService.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BicycleService.Services.Tests.User
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest()
        {
            //Arrange
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public void CreateUser_Returns_throws_InvalidBirthDateException()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                BirthDate = DateTime.UtcNow.AddHours(1),
            };

            Assert.ThrowsAsync<InvalidBirthDateException>(() => _userService.CreateUser(user));
        }

        [Fact]
        public async Task CreateUser_Returns_Correct_Response()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                BirthDate = DateTime.UtcNow
            };

            int expectedResult = 0;
            _userRepositoryMock.Setup(x => x.AddUser
                (new Domain.User.User
                    (user.UserName,
                    user.Email,
                    user.BirthDate)))
                .Returns(Task.FromResult(expectedResult));

            //Act
            var result = await _userService.CreateUser(user);

            //Assert
            Assert.IsType<Domain.User.User>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.UserId);
        }
    }
}
