using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IBookStatusRuleService
    {
        Result CheckIfNameExisted(string name, Guid? id = null);
    }
}
