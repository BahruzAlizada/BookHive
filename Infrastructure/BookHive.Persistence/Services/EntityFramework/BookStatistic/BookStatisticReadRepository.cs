using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework.BookStatistic
{
    public class BookStatisticReadRepository : ReadRepository<BookStatistics>, IBookStatisticReadRepository
    {
        private readonly Context context;
        public BookStatisticReadRepository(Context context) : base(context)
        {
            this.context = context;
        }


        public async Task<BookStatisticDto> GetBookStatistic(Guid bookId)
        {
            BookStatisticDto? bookStatistics = await context.BookStatistics.Select(x=> new BookStatisticDto
            {
                BookId = x.BookId,
                BookName = x.Book.Title,
                TotalSales = x.TotalSales,
                AverageRating = x.AverageRating,
                TotalReview = x.TotalReview
            }).FirstOrDefaultAsync(x=>x.BookId== bookId);

           

            return bookStatistics;
        }
    }
}
