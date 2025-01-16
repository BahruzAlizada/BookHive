
using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.RoleValidator
{
    public class RoleAddValidator : AbstractValidator<RoleAddDto>
    {
        public RoleAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Rol adı boş ola bilməz");
        }
    }
}
