using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;
using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Application.Rules.Concrete
{
    public class ReviewRuleService : IReviewRuleService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IBookReadRepository bookReadRepository;
        private readonly IReviewReadRepository reviewReadRepository;
        public ReviewRuleService(UserManager<AppUser> userManager, IBookReadRepository bookReadRepository, IReviewReadRepository reviewReadRepository)
        {
            this.userManager = userManager;
            this.bookReadRepository = bookReadRepository;
            this.reviewReadRepository = reviewReadRepository;
        }


        public async Task<Result> CheckBookId(Guid bookId)
        {
            Book? book = await bookReadRepository.GetFindAsync(bookId);
            if(book == null)
            {
                return new ErrorResult("Bu id-də kitab mövcud deyil");
            }
            return new Result { Success = true };
        }

        public Result CheckRating(int rating)
        {
            if (rating <= 0 || rating>5)
            {
                return new ErrorResult("Reytinqi düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public async Task<Result> CheckReviewId(Guid reviewId)
        {
            Review? review = await reviewReadRepository.GetFindAsync(reviewId);
            if (review == null)
            {
                return new ErrorResult("Bu id-də heç bir şərh mövcud deyil");
            }
            return new Result { Success = true };
        }

        public async Task<Result> CheckUserId(Guid userId)
        {
            AppUser? user = await userManager.FindByIdAsync(userId.ToString());
            if(user == null)
            {
                return new ErrorResult("Bu id-də heç bir istifadəçi mövcud deyil");
            }
            return new Result { Success = true };
        }
    }
}
