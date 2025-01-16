

using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rules.Abstract
{
    public interface IGenreRuleService
    {
        Result CheckIfNameExisted(string name, Guid categoryId, Guid? id = null);
    }
}
