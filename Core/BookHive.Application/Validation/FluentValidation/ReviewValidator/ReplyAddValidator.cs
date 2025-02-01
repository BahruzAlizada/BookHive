using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.ReviewValidator
{
    public class ReplyAddValidator : AbstractValidator<ReplyAddDto>
    {
        public ReplyAddValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id boş ola bilməz");
            RuleFor(x => x.ParentId).NotEmpty().WithMessage("Parent id boş ola bilməz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Kitab şərhi boş ola bilməz");
        }
    }
}
