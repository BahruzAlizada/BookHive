using BookHive.Application.DTOs;
using FluentValidation;

namespace BookHive.Application.Validation.FluentValidation.BookValidator
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Kitab adı boş ola bilməz");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Kitab haqqında boş ola bilməz");
            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN boş ola bilməz");
            RuleFor(x => x.CoverImageUrl)
                .NotEmpty().WithMessage("Kitab şəkli boş ola bilməz");
            RuleFor(x => x.Pages)
                .NotEmpty().WithMessage("Kitab səhifəsinin sayı boş ola bilməz");
            RuleFor(x => x.GenreId)
                .NotEmpty().WithMessage("Kitabın janr id-i boş ola bilməz");
            RuleFor(x => x.PublisherId)
                .NotEmpty().WithMessage("Nəşriyyat id-i boş ola bilməz");
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Yazıçı id-i boş ola bilməz");
            RuleFor(x => x.BookLanguageId)
                .NotEmpty().WithMessage("kitab dilinin id-i boş ola bilməz");
            RuleFor(x => x.BookStatusId)
                .NotEmpty().WithMessage("Kitab statusunun id-i boş ola bilməz");
        }
    }
}
