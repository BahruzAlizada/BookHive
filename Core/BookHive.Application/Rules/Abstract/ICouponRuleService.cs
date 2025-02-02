
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface ICouponRuleService 
    {
        Result CheckCode(string code, Guid? id = null);
        Result CheckExpiryDate(DateTime expiryDate);
        Result CheckDiscount(double discount);
    }
}
