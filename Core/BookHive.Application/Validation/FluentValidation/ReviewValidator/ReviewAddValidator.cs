

using BookHive.Application.DTOs.Review;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.ReviewValidator
{
    public class ReviewAddValidator : AbstractValidator<ReviewAddDto>
    {
        public ReviewAddValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("User Id boş ola bilməz");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Kitab Id boş ola bilməz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Kitab şərhi boş ola bilməz");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Kitab reytinqi boş ola bilməz");
        }
    }
}
