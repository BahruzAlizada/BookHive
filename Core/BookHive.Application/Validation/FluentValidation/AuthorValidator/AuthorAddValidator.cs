using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.AuthorValidator
{
    public class AuthorAddValidator : AbstractValidator<AuthorAddDto>
    {
        public AuthorAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Müəllif adı boş ola bilməz");

            RuleFor(x => x.Bio)
                .NotEmpty().WithMessage("Müəllif haqqında yazı boş ola bilməz");

        }
    }
}
