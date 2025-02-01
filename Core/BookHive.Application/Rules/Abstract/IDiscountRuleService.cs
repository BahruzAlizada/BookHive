

using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IDiscountRuleService
    {
        Task<Result> CheckGenre(Guid genreId);
        Task<Result> CheckBook(Guid bookId);
        Result CheckDiscountPrice(int discountPrice);
    }
}
