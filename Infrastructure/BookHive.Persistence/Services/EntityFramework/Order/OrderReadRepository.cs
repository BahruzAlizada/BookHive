using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(Context context) : base(context)
        {
        }
    }
}
