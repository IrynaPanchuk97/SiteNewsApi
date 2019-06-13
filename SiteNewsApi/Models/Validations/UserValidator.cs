using FluentValidation;
using SiteNewsApi.Models.DTOs;

namespace SiteNewsApi.Models.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .Null()
                .Empty()
                .EmailAddress();
            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .Length(6, 25)
                .WithMessage("Password can not be empty");
            RuleFor(u => u.Login)
                .NotNull()
                .NotEmpty()
                .Length(6, 50)
                .WithMessage("Login can not be empty");
        }
    }
}
