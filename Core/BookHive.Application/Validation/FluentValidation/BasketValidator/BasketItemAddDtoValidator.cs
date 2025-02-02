

using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.BasketValidator
{
    public class BasketItemAddDtoValidator : AbstractValidator<BasketItemAddDto>
    {
        public BasketItemAddDtoValidator()
        {
            RuleFor(x=>x.BookId).NotEmpty().WithMessage("Kitab id-i boş ola bilməz");
        }
    }
}
