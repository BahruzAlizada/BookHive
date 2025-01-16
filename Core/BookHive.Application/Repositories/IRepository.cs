using Microsoft.EntityFrameworkCore;
using BookHive.Domain.Common;

namespace BookHive.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
