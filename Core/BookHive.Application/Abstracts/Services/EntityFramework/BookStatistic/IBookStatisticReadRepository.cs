using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IBookStatisticReadRepository : IReadRepository<BookStatistics>
    {
        Task<BookStatisticDto> GetBookStatistic(Guid bookId);
    }
}
