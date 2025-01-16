

using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs.Book;
using BookHive.Domain.Entities;
using BookHive.Persistence.Context;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        private readonly AppDbContext context;
        public BookReadRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<BookDto> GetBookAsync(Guid id)
        {
            Book? book = await context.Books.Include(x => x.Publisher).Include(x => x.Author).Include(x => x.BookLanguage).
                Include(x => x.BookStatus).Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return null;

            BookDto bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                CoverImageUrl = book.CoverImageUrl,
                Description = book.Description,
                Pages = book.Pages,
                ISBN = book.ISBN,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher.Name,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name,
                GenreId = book.GenreId,
                GenreName = book.Genre.Name,
                BookLanguageId = book.BookLanguageId,
                BookLanguageName = book.BookLanguage.Name,
                BookStatusId = book.BookStatusId,
                BookStatusName = book.BookStatus.Name
            };

            return bookDto;
        }

        public async Task<List<BookDto>> GetBookDtosAsync()
        {
            List<Book> books = await context.Books.Include(x=>x.Publisher).Include(x=>x.Author).Include(x=>x.BookLanguage).
                Include(x=>x.BookStatus).Include(x=>x.Genre).ToListAsync();
            List<BookDto> bookDtos = new List<BookDto>();

            foreach (var book in books)
            {
                BookDto dto = new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    CoverImageUrl = book.CoverImageUrl,
                    Description = book.Description,
                    Pages = book.Pages,
                    ISBN = book.ISBN,
                    PublisherId = book.PublisherId,
                    PublisherName = book.Publisher.Name,
                    AuthorId = book.AuthorId,
                    AuthorName = book.Author.Name,
                    GenreId = book.GenreId,
                    GenreName = book.Genre.Name,
                    BookLanguageId = book.BookLanguageId,
                    BookLanguageName = book.BookLanguage.Name,
                    BookStatusId = book.BookStatusId,
                    BookStatusName = book.BookStatus.Name
                };
                bookDtos.Add(dto);
            }

            return bookDtos;
        }
    }
}
