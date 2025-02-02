using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Review;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class ReviewWriteRepository : WriteRepository<Review>, IReviewWriteRepository
    {
        private readonly Context context;
        public ReviewWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task AddReplyAsync(ReplyAddDto replyAddDto)
        {
            Review? review = await context.Reviews.SingleOrDefaultAsync(x => x.IsMain && x.Id == replyAddDto.ParentId);
            if (review == null)
                throw new Exception("Review not found");

            Review reply = new Review
            {
                ParentId = review.Id,
                UserId = replyAddDto.UserId,
                IsMain = false,
                Comment = replyAddDto.Comment,
                BookId = review.BookId,
            };

            await context.Reviews.AddAsync(reply);

            BookStatistics? bookStatistics = await context.BookStatistics.SingleOrDefaultAsync(x => x.BookId == review.BookId);
            if (bookStatistics == null)
                throw new Exception("Book statistics not found");

            bookStatistics.TotalReview++;
            context.BookStatistics.Update(bookStatistics);
            await context.SaveChangesAsync();
        }

        public async Task AddReviewAsync(ReviewAddDto reviewAddDto)
        {
            Review review = new Review
            {
                BookId = reviewAddDto.BookId,
                UserId = reviewAddDto.UserId,
                Comment = reviewAddDto.Comment,
                Rating = reviewAddDto.Rating,
                IsMain = true
            };

            await context.Reviews.AddAsync(review);

            BookStatistics? bookStatistics = await context.BookStatistics.FirstOrDefaultAsync(x=>x.BookId==reviewAddDto.BookId);
            if (bookStatistics == null)
                throw new Exception("BookStatistics not found");

            bookStatistics.TotalReview++;
            bookStatistics.AverageRating = (double)((bookStatistics.AverageRating * (bookStatistics.TotalReview - 1)) + reviewAddDto.Rating) / bookStatistics.TotalReview;

            context.BookStatistics.Update(bookStatistics);
            await context.SaveChangesAsync();
        }
    }
}
