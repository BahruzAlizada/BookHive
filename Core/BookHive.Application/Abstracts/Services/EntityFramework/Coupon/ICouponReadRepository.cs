using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface ICouponReadRepository : IReadRepository<Coupon>
    {
    }
}
