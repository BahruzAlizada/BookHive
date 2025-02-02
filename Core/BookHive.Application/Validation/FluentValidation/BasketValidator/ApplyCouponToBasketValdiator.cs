

using BookHive.Application.DTO;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.BasketValidator
{
    public class ApplyCouponToBasketValdiator : AbstractValidator<ApplyCouponToBasketDto>
    {
        public ApplyCouponToBasketValdiator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Kupon adı boş ola bilməz");
            RuleFor(x => x.BasketId).NotEmpty().WithMessage("Səbət id-i boş ola bilməz");
        }
    }
}
