﻿using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.GenreValidator
{
    public class GenreUpdateValidator : AbstractValidator<GenreUpdateDto>
    {
        public GenreUpdateValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Janr adı boş ola bilməz");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kateqoriya id-i boş ola bilməz");
        }
    }
}
