using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.ViewModels
{
    public class BicycleViewModel
    {
        public int BicycleId { get; set; }
        public int UserId { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string Type { get; set; }
    }
}
