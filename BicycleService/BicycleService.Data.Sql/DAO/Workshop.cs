using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleService.Data.Sql.DAO
{
    public class Workshop
    {
        public Workshop()
        {
            Services = new List<Service>();
        }

        public int WorkshopId { get; set; }
        public string Address { get; set; }
        public int? EmployeeCount { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
