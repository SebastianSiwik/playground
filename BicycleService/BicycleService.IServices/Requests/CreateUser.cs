using System;

namespace BicycleService.IServices.Requests
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
