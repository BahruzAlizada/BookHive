
using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.UserValidator
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz");
        }
    }
}
