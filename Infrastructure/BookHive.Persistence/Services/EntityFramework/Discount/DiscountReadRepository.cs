using BookHive.Application.Abstracts.Services;
using BookHive.Domain.Entities;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class DiscountReadRepository : ReadRepository<BookDiscount>, IDiscountReadRepository
    {
        public DiscountReadRepository(Context context) : base(context)
        {
        }
    }
}
