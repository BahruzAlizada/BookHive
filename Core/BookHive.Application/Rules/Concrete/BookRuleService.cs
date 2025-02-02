using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;
using BookHive.Domain.Entities;

namespace BookHive.Application.Rules.Concrete
{
    public class BookRuleService : IBookRuleService
    {
        private readonly IBookReadRepository bookReadRepository;
        private readonly IAuthorReadRepository authorReadRepository;
        private readonly IGenreReadRepository genreReadRepository;
        private readonly IPublisherReadRepository publisherReadRepository;
        public BookRuleService(IBookReadRepository bookReadRepository, IAuthorReadRepository authorReadRepository, IGenreReadRepository genreReadRepository, IPublisherReadRepository publisherReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
            this.authorReadRepository = authorReadRepository;
            this.genreReadRepository = genreReadRepository;
            this.publisherReadRepository = publisherReadRepository;
        }

        public async Task<Result> CheckAuthorId(Guid authorId)
        {
            Author? author = await authorReadRepository.GetFindAsync(authorId);
            if (author == null)
            {
                return new ErrorResult("Müəllifin id-ni düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public Result CheckBookLanguage(int language)
        {
            if(language < 1 || language > 4)
            {
                return new ErrorResult("Kitabın dilini düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public async Task<Result> CheckGenreId(Guid genreId)
        {
            Genre? genre = await genreReadRepository.GetFindAsync(genreId);
            if (genre == null)
            {
                return new ErrorResult("Janr id-ni düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public Result CheckIfISBNExisted(string ISBN, Guid? id = null)
        {
            if (id.HasValue)
            {
                var bookExist = bookReadRepository.GetAll(false).Any(x => x.ISBN == ISBN && x.Id != id.Value);
                if (bookExist)
                {
                    return new ErrorResult("ISBN artıq mövcuddur");
                }
            }
            else
            {
                var bookExist = bookReadRepository.GetAll(false).Any(x => x.ISBN == ISBN);
                if (bookExist)
                {
                    return new ErrorResult("ISBN artıq mövcuddur");
                }
            }

            return new Result { Success = true };
        }

        public Result CheckPages(int page)
        {
            if (page <= 0)
            {
                return new ErrorResult("Səhifə sayını düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public Result CheckPrice(double price)
        {
            if (price <= 0 || price>1000)
            {
                return new ErrorResult("Qiymət 1-1000 manat arasında olmalıdır");
            }
            return new Result { Success = true };
        }

        public async Task<Result> CheckPublisherId(Guid publisherId)
        {
            Publisher? publisher = await publisherReadRepository.GetFindAsync(publisherId);
            if (publisher == null)
            {
                return new ErrorResult("Nəşriyyat id-ni düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public Result CheckQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                return new ErrorResult("Kitab sayı 0-dan böyük olmalıdır");
            }
            return new Result { Success=true };
        }
    }
}
