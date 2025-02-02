using BookHive.Application.DTOs;
using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services
{
    public interface ICouponWriteRepository : IWriteRepository<Coupon>
    {
    }
}
