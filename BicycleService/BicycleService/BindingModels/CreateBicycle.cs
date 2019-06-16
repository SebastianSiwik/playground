using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.BindingModels
{
    public class CreateBicycle
    {
        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "ProductionDate")]
        public DateTime? ProductionDate { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }
    }
}
