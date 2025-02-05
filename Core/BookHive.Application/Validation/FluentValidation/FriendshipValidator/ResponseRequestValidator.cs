

using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.FriendshipValidator
{
    public class ResponseRequestValidator : AbstractValidator<ResponseRequestDto>
    {
        public ResponseRequestValidator()
        {
            RuleFor(x => x.FriendshipId).NotEmpty().WithMessage("Dostluq id-i boş ola bilməz");
        }
    }
}
