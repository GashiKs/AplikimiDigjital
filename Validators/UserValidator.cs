using FluentValidation;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;

namespace AplikimiDigjital.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(x => x.ID).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().WithMessage("Fill the Name Field!");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have 2 characters at least!");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Fill the Surname Field!");
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).WithMessage("Surname should have 2 characters at least!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Fill the Email Field!");
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Give a Password!");
        }
    }
}
