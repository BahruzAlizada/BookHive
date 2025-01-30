using BookHive.Application.Parametres.ResponseParametres;
using FluentValidation;
using FluentValidation.Results;

namespace BookHive.Application.Extensions.FluentValidationExtension
{
    public static class ValidationExtension
    {
        public static string ValidationErrorString(this ValidationResult validationResult)
        {
            return string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
        }

        public static async Task<BookHive.Application.Parametres.ResponseParametres.Result> ValidatorResult<T>(AbstractValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);
            if (!validationResult.IsValid)
            {
                return new ErrorResult(validationResult.ValidationErrorString());
            }
            return new Result { Success = true };
        }
    }
}
