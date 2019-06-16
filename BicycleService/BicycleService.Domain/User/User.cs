using BicycleService.Domain.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleService.Domain.User
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string Address { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsBannedUser { get; private set; }
        public string UserStatus { get; private set; }

        public User(string userName, string email, DateTime birthDate)
        {
            if(birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            UserName = userName;
            UserEmail = email;
            RegistrationDate = DateTime.UtcNow;
            BirthDate = birthDate;
            IsBannedUser = false;
            UserStatus = Utils.Enums.UserStatus.User.ToString();
        }
    }
}
