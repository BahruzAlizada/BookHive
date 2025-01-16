using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class BookStatusRuleService : IBookStatusRuleService
    {
        private readonly IBookStatusReadRepository bookStatusReadRepository;
        public BookStatusRuleService(IBookStatusReadRepository bookStatusReadRepository)
        {
            this.bookStatusReadRepository = bookStatusReadRepository;
        }



        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var bookStatusExist = bookStatusReadRepository.GetAll(false).Any(x => x.Name == name && x.Id != id.Value);

                if (bookStatusExist)
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
                var bookStatusExist = bookStatusReadRepository.GetAll(false).Any(x => x.Name == name);
                if (bookStatusExist)
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
