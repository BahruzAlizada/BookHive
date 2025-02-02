using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class CouponRuleService : ICouponRuleService
    {
        private readonly ICouponReadRepository couponReadRepository;
        public CouponRuleService(ICouponReadRepository couponReadRepository)
        {
            this.couponReadRepository=couponReadRepository;
        }


        public Result CheckCode(string code, Guid? id = null)
        {
            if (id.HasValue)
            {
                var couponExist = couponReadRepository.GetAll().Any(x => x.Code == code && x.Id != id);
                if (couponExist)
                {
                    return new ErrorResult(Messages.CheckIfNameExisted);
                }
            }
            else
            {
                var couponExist = couponReadRepository.GetAll().Any(x => x.Code == code);
                if (couponExist)
                {
                    return new ErrorResult(Messages.CheckIfNameExisted);
                }
            }
            return new Result { Success = true };
        }

        public Result CheckDiscount(double discount)
        {
            if (discount <= 0)
            {
                return new ErrorResult("Məbləği düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true }; 
        }

        public Result CheckExpiryDate(DateTime expiryDate)
        {
            if(DateTime.Now.Date>=expiryDate.Date)
            {
                return new ErrorResult("Son tarixi düzgün daxil etmək lazımdır");
            }
            return new Result { Success = true };
        }
    }
}
