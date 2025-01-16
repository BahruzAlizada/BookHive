using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation
{
    public class BookStatusUpdateValidator : AbstractValidator<BookStatusUpdateDto>
    {
        public BookStatusUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Status adı boş ola bilməz");
        }
    }
}
