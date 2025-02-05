
using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.FriendshipValidator
{
    public class SendRequestValidator : AbstractValidator<SendRequestDto>
    {
        public SendRequestValidator()
        {
            RuleFor(x=>x.RequesterId).NotEmpty().WithMessage("Dostluq göndərən istifadəçi boş ola bilməz");
            RuleFor(x => x.AddresseeId).NotEmpty().WithMessage("Dostluq alan istifadəçi boş ola bilməz");
        }
    }
}
