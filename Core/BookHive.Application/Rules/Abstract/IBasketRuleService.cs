

using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IBasketRuleService
    {
        Result CheckBasketItemQuantity(int quantity);
        Task<Result> CheckBookAvailability(Guid bookId, int quantity);
        Task<Result> CheckBasketCouponExpiryDate(string code);
    }
}
