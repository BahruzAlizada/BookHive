using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation
{
    public class BookLanguageAddValidator : AbstractValidator<BookLanguageAddDto>
    {
        public BookLanguageAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dil adı boş ola bilməz");
        }
    }
}
