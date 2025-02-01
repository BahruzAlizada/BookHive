
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IReviewRuleService
    {
        Result CheckRating(int rating);
        Task<Result> CheckBookId(Guid bookId);
        Task<Result> CheckUserId(Guid userId);
        Task<Result> CheckReviewId(Guid reviewId);
    }
}
