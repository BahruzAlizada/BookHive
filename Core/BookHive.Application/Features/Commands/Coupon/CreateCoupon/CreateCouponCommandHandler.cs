
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.CouponValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Coupon.CreateCoupon
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommandRequest, CreateCouponCommandResponse>
    {
        private readonly ICouponWriteRepository couponWriteRepository;
        private readonly ICouponRuleService couponRuleService;
        public CreateCouponCommandHandler(ICouponWriteRepository couponWriteRepository, ICouponRuleService couponRuleService)
        {
            this.couponWriteRepository = couponWriteRepository;
            this.couponRuleService = couponRuleService;
        }


        public async Task<CreateCouponCommandResponse> Handle(CreateCouponCommandRequest request, CancellationToken cancellationToken)
        {
            var validationExtension = await ValidationExtension.ValidatorResult(new CouponAddValidator(), request.couponAddDto);
            if (!validationExtension.Success) return new() { Result = validationExtension };

            var result = BusinessRules.Run(couponRuleService.CheckCode(request.couponAddDto.Code), couponRuleService.CheckDiscount(request.couponAddDto.Discount),
                couponRuleService.CheckExpiryDate(request.couponAddDto.ExpiryDate));
            if (!result.Success) return new() {Result = result};

            BookHive.Domain.Entities.Coupon coupon = request.couponAddDto.Adapt<BookHive.Domain.Entities.Coupon>();

            await couponWriteRepository.AddAsync(coupon);
            await couponWriteRepository.SaveAsync();
            return new() { Result = new SuccessResult(Messages.SuccessAdded) };

        }
    }
}
