using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class BookLanguageRuleService : IBookLanguageRuleService
    {
        private readonly IBookLanguageReadRepository bookLanguageReadRepository;
        public BookLanguageRuleService(IBookLanguageReadRepository bookLanguageReadRepository)
        {
            this.bookLanguageReadRepository = bookLanguageReadRepository;
        }


        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var bookLanguageStatus = bookLanguageReadRepository.GetAll(false).Any(x => x.Name == name && x.Id != id.Value);

                if (bookLanguageStatus)
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
                var bookLanguageStatus = bookLanguageReadRepository.GetAll(false).Any(x => x.Name == name);
                if (bookLanguageStatus)
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
