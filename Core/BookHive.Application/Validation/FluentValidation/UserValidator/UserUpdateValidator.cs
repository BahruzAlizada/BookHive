using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.UserValidator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.FullName)
               .NotEmpty().WithMessage("İstifadəçi adı və soyadı boş ola bilməz");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş ola bilməz")
                .EmailAddress().WithMessage("Email adresini düzgün qeyd etmək lazımdır");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz");
        }
    }
}
