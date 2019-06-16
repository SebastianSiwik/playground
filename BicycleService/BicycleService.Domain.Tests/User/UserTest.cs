using BicycleService.Domain.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BicycleService.Domain.Tests.User
{
    public class UserTest
    {
        public UserTest()
        {
        }

        [Fact]
        public void CreateUser_Returns_throws_InvalidBirthDateException()
        {
            Assert.Throws<InvalidBirthDateException>
                (() => new Domain.User.User(
                    "Name",
                    "Email",
                    DateTime.UtcNow.AddHours(1)));
        }

        [Fact]
        public void CreateUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email", DateTime.UtcNow);

            Assert.Equal("Email", user.UserEmail);
            Assert.Equal("Name", user.UserName);
        }
    }
}
