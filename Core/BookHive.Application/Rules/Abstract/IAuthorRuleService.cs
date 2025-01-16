
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IAuthorRuleService
    {
        Result CheckIfNameExisted(string name, Guid? id = null);
    }
}
