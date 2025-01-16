using Microsoft.AspNetCore.Identity;

namespace BookHive.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
