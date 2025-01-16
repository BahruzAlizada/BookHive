using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.UserValidator
{
    public class UpdatePasswordValidator :AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz");
            RuleFor(x => x.PasswordConfirm)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz");
        }
    }
}
