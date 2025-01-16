using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;
using BookHive.Domain.Common;

namespace BookHive.Application.Rules.Concrete
{
    public class CategoryRuleService : ICategoryRuleService
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        public CategoryRuleService(ICategoryReadRepository categoryReadRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
        }


        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var categoryExist = categoryReadRepository.GetAll(false).Any(x => x.Name == name && x.Id != id.Value);

                if (categoryExist)
                {
                    return new Result
                    {
                        Success = false,
                        Message = Messages.CheckIfNameExisted
                    };
                }
            }
            else
            {
                var categoryExist = categoryReadRepository.GetAll(false).Any(x => x.Name == name);
                if (categoryExist)
                {
                    return new Result
                    {
                        Success = false,
                        Message = Messages.CheckIfNameExisted
                    };
                }
            }

            return new Result
            {
                Success = true,
            };
        }


    }
}
