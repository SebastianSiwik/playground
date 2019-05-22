using System;
using System.Collections.Generic;
using BicycleService.Utils.Enums;
using System.Text;

namespace BicycleService.Data.Sql.DAO
{
    public class Bicycle
    {
        public Bicycle()
        {
            Faults = new List<Fault>();
        }

        public int BicycleId { get; set; }
        public int UserId { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string Type { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Fault> Faults { get; set; }

    }
}
