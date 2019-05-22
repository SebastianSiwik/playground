using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleService.Data.Sql.DAO
{
    public class Service
    {
        public Service()
        {
            Faults = new List<Fault>();
        }

        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int WorkshopId { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public virtual Workshop Workshop { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Fault> Faults { get; set; }
    }
}
