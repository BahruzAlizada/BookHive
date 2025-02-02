using BookHive.Application.Abstracts.Services;
using BookHive.Application.DTOs;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class CouponWriteRepository : WriteRepository<Coupon>, ICouponWriteRepository
    {
        private readonly Context context;
        public CouponWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }

      
    }
}
