using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.DiscountValidator
{
    public class DiscountBookValidator : AbstractValidator<DiscountBookDto>
    {
        public DiscountBookValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Kitab İd-i boş ola bilməz");
        }
    }
}
