

using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.CouponValidator
{
    public class CouponAddValidator : AbstractValidator<CouponAddDto>
    {
        public CouponAddValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Kupon kodu boş ola bilməz");
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage("Son tarix boş ola bilməz");
        }
    }
}
