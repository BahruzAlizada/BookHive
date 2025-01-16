﻿using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.CategoryValidator
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz");
        }
    }
}
