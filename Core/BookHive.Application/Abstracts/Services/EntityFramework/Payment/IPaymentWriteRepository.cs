using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IPaymentWriteRepository : IWriteRepository<Payment>
    {

    }
}
