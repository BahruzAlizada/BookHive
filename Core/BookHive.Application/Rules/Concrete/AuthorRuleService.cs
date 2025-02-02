using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class AuthorRuleService : IAuthorRuleService
    {
        private readonly IAuthorReadRepository authorReadRepository;
        public AuthorRuleService(IAuthorReadRepository authorReadRepository)
        {
            this.authorReadRepository = authorReadRepository;
        }


        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var authorExist = authorReadRepository.GetAll(false).Any(x => x.Name == name && x.Id != id.Value);
                if (authorExist)
                {
                    return new ErrorResult(Messages.CheckIfNameExisted);
                }
            }
            else
            {
                var authorExist = authorReadRepository.GetAll(false).Any(x => x.Name == name);
                if (authorExist)
                {
                    return new ErrorResult(Messages.CheckIfNameExisted);
                }
            }

            return new Result { Success = true };
        }
    }
}
