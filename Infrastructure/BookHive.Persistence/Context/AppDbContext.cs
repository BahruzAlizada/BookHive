using BookHive.Domain.Entities;
using BookHive.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BookHive.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public static string SqlConnection = "Server=DESKTOP-DQGN1O7;Database=BookHive;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection);
        }
         
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
    }
}
