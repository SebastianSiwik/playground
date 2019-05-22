using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleService.Api.BindingModels
{
    public class EditUser
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }

        public class EditUserValidator : AbstractValidator<EditUser>
        {
            public EditUserValidator()
            {
                RuleFor(x => x.UserName).NotNull();
                RuleFor(x => x.UserEmail).EmailAddress();
                RuleFor(x => x.BirthDate).NotNull();
            }
        }
    }
}
