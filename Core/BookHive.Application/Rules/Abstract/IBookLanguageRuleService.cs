using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IBookLanguageRuleService
    {
        Result CheckIfNameExisted(string name, Guid? id = null);
    }
}
