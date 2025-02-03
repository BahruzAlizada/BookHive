using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        private readonly Context context;
        public BookReadRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<BookDto>> GetBookAllDtos()
        {
            List<BookDto> books = await context.Books.Include(x=>x.Author).Include(x=>x.Genre).Include(x=>x.Publisher).Include(x=>x.BookStatistics)
            .Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ISBN = x.ISBN,
                Price = x.Price,
                DiscountPrice = x.DiscountPrice,
                Quantity = x.Quantity,
                Pages = x.Pages,
                CoverImageUrl = x.CoverImageUrl,
                AuthorId = x.AuthorId,
                PublisherId = x.PublisherId,
                GenreId = x.GenreId,
                AuthorName = x.Author.Name,
                PublisherName = x.Publisher.Name,
                GenreName = x.Genre.Name,
                BookLanguage = x.BookLanguage.ToString(),
                BookStatus = x.BookStatus.ToString(),
                AverageRating = x.BookStatistics.AverageRating,
                TotalReview = x.BookStatistics.TotalReview
            }).ToListAsync();

            return books;
        }



    }
}
