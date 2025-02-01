using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Review;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface IReviewWriteRepository : IWriteRepository<Review>
    {
        Task AddReviewAsync(ReviewAddDto reviewAddDto);
        Task AddReplyAsync(ReplyAddDto replyAddDto);
    }
}
