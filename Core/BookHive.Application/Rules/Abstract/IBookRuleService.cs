
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IBookRuleService
    {
        Task<Result> CheckGenreId(Guid genreId);
        Task<Result> CheckAuthorId(Guid authorId);
        Task<Result> CheckPublisherId(Guid publisherId);
        Result CheckIfISBNExisted(string ISBN, Guid? id = null);
        Result CheckQuantity(int quantity);
        Result CheckPrice(double price);
        Result CheckPages(int page);
        Result CheckBookLanguage(int language); 
    }
}
