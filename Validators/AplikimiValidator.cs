using FluentValidation;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;

namespace AplikimiDigjital.Validators
{
    public class AplikimiValidator : AbstractValidator<Aplikimi>
    {
        public AplikimiValidator()
        {
            //RuleFor(x => x.ID).NotEmpty().WithMessage("Fill the ID Field!");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Fill the Name Field!");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have 2 characters at least!");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Fill the Surname Field!");
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).WithMessage("Surname should have 2 characters at least!");

            RuleFor(x => x.StudentID).NotEmpty().WithMessage("Fill the Student ID Field!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Fill the Email Field!");
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.NumriTelefonit).NotEmpty().WithMessage("Fill the Numri Telefonit Field!");
        }
    }
}
