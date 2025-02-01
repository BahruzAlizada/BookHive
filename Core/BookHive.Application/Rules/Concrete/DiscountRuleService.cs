

using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;
using BookHive.Domain.Entities;

namespace BookHive.Application.Rules.Concrete
{
    public class DiscountRuleService : IDiscountRuleService
    {
        private readonly IBookReadRepository bookReadRepository;
        private readonly IGenreReadRepository genreReadRepository;
        public DiscountRuleService(IBookReadRepository bookReadRepository, IGenreReadRepository genreReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
            this.genreReadRepository = genreReadRepository;
        }

        public async Task<Result> CheckBook(Guid bookId)
        {
            Book? book = await bookReadRepository.GetFindAsync(bookId);
            if (book == null)
            {
                return new ErrorResult(Messages.IdNull);
            }
            return new Result { Success = true };
        }

        public Result CheckDiscountPrice(int discountPrice)
        {
            if (discountPrice <= 0)
            {
                return new ErrorResult("Endirim faizini düzgün təyin etmək lazımdır");
            }
            if (discountPrice > 90)
            {
                return new ErrorResult("Endirim faizini maksimum 90%-ə qədər ola bilər");
            }
            return new Result { Success = true };

        }

        public async Task<Result> CheckGenre(Guid genreId)
        {
            Genre? genre = await genreReadRepository.GetFindAsync(genreId);
            if (genre == null)
            {
                return new ErrorResult(Messages.IdNull);
            }
            return new Result { Success = true };
        }
    }
}
