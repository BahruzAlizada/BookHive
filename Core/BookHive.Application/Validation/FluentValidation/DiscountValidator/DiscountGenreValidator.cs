using BookHive.Application.DTOs.Discount;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.DiscountValidator
{
    public class DiscountGenreValidator : AbstractValidator<DiscountGenreDto>
    {
        public DiscountGenreValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Janr İd-i boş ola bilməz");
        }
    }
}
