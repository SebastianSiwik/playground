using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.BindingModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
    }
}
