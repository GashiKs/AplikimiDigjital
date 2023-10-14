using FluentValidation;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;

namespace AplikimiDigjital.Validators
{
    public class CommentValidator: AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Fill the Name Field!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Fill the Email Field!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Fill the Description Field!");
        }
    }
}
