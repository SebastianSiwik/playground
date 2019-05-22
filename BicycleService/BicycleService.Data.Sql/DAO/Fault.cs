using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleService.Data.Sql.DAO
{
    public class Fault
    {
        public int FaultId { get; set; }
        public int BicycleId { get; set; }
        public int ServiceId { get; set; }
        public string FaultDescription { get; set; }
        public string FaultCircumstances { get; set; }
        public string InvolvedPart { get; set; }

        public virtual Bicycle Bicycle { get; set; }
        public virtual Service Service { get; set; }
    }
}
