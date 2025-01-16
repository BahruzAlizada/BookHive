using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.CategoryValidator
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz");
        }
    }
}
