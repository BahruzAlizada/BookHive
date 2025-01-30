using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        private readonly Context context;
        public BookWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task AddBookAsync(BookAddDto bookAddDto)
        {
            Book book = new Book
            {
                Title = bookAddDto.Title,
                Description = bookAddDto.Description,
                ISBN = bookAddDto.ISBN,
                Quantity = bookAddDto.Quantity,
                Price = bookAddDto.Price,
                Pages = bookAddDto.Pages,
                GenreId = bookAddDto.GenreId,
                PublisherId = bookAddDto.PublisherId,
                AuthorId = bookAddDto.AuthorId,
                BookLanguage = bookAddDto.BookLanguage,
                //BookStatus = bookAddDto.BookStatus,

            };

            await context.Books.AddAsync(book);

            BookStatistics bookStatistics = new BookStatistics
            {
                BookId = book.Id,
                AverageRating = 0,
                TotalReview = 0,
                TotalSales = 0,
            };

            await context.AddAsync(bookStatistics);
            await context.SaveChangesAsync();
        }
    }
}
