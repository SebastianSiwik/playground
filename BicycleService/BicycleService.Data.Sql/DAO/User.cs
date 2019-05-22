using BicycleService.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleService.Data.Sql.DAO
{
    public class User
    {
        public User()
        {
            Bicycles = new List<Bicycle>();
            Services = new List<Service>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsBannedUser { get; set; }
        public string UserStatus { get; set; }

        public virtual ICollection<Bicycle> Bicycles { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }
}
