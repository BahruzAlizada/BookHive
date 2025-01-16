
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IBookRuleService
    {
        public Result CheckIfISBNExisted(string ISBN, Guid? id = null);
    }
}
