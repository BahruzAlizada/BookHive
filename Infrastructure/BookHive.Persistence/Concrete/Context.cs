using BookHive.Domain.Entities;
using BookHive.Domain.Enums;
using BookHive.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public static string SqlConnection = "Server=DESKTOP-DQGN1O7;Database=BookHiveDatabase;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookDiscount> BookDiscounts { get; set; }
        public DbSet<BookStatistics> BookStatistics { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponUsage> CouponUsages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }


        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
    }
}

