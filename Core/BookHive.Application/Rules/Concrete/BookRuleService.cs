using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class BookRuleService : IBookRuleService
    {
        private readonly IBookReadRepository bookReadRepository;
        public BookRuleService(IBookReadRepository bookReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
        }


        public Result CheckIfISBNExisted(string ISBN, Guid? id = null)
        {
            if (id.HasValue)
            {
                var bookExist = bookReadRepository.GetAll(false).Any(x => x.ISBN == ISBN && x.Id != id.Value);

                if (bookExist)
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
                var bookExist = bookReadRepository.GetAll(false).Any(x => x.ISBN == ISBN);
                if (bookExist)
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
