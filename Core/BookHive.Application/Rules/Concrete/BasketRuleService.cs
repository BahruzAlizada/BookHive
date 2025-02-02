
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;
using BookHive.Domain.Entities;

namespace BookHive.Application.Rules.Concrete
{
    public class BasketRuleService : IBasketRuleService
    {
        private readonly ICouponReadRepository couponReadRepository;
        private readonly IBookReadRepository bookReadRepository;
        private readonly IBasketItemReadRepository basketItemReadRepository;
        public BasketRuleService(ICouponReadRepository couponReadRepository, IBookReadRepository bookReadRepository, IBasketItemReadRepository basketItemReadRepository)
        {
            this.couponReadRepository = couponReadRepository;
            this.bookReadRepository = bookReadRepository;
            this.basketItemReadRepository = basketItemReadRepository;
        }
        public async Task<Result> CheckBasketCouponExpiryDate(string code)
        {
            Coupon coupon  =await couponReadRepository.GetSingleAsync(x=>x.Code==code);
            if (coupon.ExpiryDate.Date<=DateTime.Now.Date)
            {
                return new ErrorResult("Bu kuponun istifadə müddəti bitibdir");
            }
            return new Result { Success = true };
        }

        public Result CheckBasketItemQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                return new ErrorResult("Kitab sayını düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }

        public async Task<Result> CheckBookAvailability(Guid bookId, int quantity)
        {
            BookHive.Domain.Entities.Book? book = await bookReadRepository.GetFindAsync(bookId);
            if (book == null)
            {
                return new ErrorResult(Messages.IdNull);
            }

            int bookQuantity = await basketItemReadRepository.GetBasketItemBookQuantity(bookId);
            int totalbasketBookQuantity = quantity + bookQuantity;

            if (book.Quantity < quantity)
            {
                return new ErrorResult($"Bu kitabdan stokda sadəcə {book.Quantity} ədəd qalıbdır.");
            }
            if (totalbasketBookQuantity > book.Quantity)
            {

                return new ErrorResult("bu dəyər Kitabın stok sayını aşır");
            }

            return new Result { Success = true };
        }
    }
}
