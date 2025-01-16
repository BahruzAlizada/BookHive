using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.PublisherValidator
{
    public class PublisherAddValidator : AbstractValidator<PublisherAddDto>
    {
        public PublisherAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nəşriyyatın adı boş ola bilməz");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Nəşriyyatın adresi boş ola bilməz");
            RuleFor(x=>x.ContactNumber)
                .NotEmpty().WithMessage("Nəşriyyatın nömrəsi boş ola bilməz")
                .Matches(@"^\d{10}$").WithMessage("Telefon nömrəsi yalnız rəqəmlərdən ibarət olmalı və 10 rəqəmdən ibarət olmalıdır.");
        }
    }
}
