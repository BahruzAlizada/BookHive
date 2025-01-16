
using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation
{
    public class BookStatusAddValidator : AbstractValidator<BookStatusAddDto>
    {
        public BookStatusAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Status adı boş ola bilməz");
        }
    }
}
