using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.BindingModels
{
    public class EditBicycle
    {
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "ProductionDate")]
        public DateTime? ProductionDate { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        public class EditBicycleValidator : AbstractValidator<EditBicycle>
        {
            public EditBicycleValidator()
            {
                RuleFor(x => x.UserId).NotNull();
                RuleFor(x => x.ProductionDate).NotNull();
                RuleFor(x => x.Type).NotNull();
            }
        }
    }
}
