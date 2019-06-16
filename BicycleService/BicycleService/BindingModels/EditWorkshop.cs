using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.BindingModels
{
    public class EditWorkshop
    {
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Employee count")]
        public int EmployeeCount { get; set; }

        public class EditWorkshopValidator: AbstractValidator<EditWorkshop>
        {
            public EditWorkshopValidator()
            {
                RuleFor(x => x.Address).NotNull();
                RuleFor(x => x.EmployeeCount).NotNull();
            }
        }
    }
}
