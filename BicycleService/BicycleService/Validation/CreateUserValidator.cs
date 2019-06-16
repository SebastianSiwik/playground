using BicycleService.Api.BindingModels;
using FluentValidation;

namespace BicycleService.Api.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.UserEmail).NotNull().EmailAddress();

        }
    }
}
