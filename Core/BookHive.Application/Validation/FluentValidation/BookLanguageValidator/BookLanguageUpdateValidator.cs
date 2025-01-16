using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation
{
    public class BookLanguageUpdateValidator : AbstractValidator<BookLanguageUpdateDto>
    {
        public BookLanguageUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dil adı boş ola bilməz");
        }
    }
}
