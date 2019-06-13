using FluentValidation;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models.Validations
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(u => u.UsersNews)
                .NotNull()
                .NotEmpty();
        }
    }
}
