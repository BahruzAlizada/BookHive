using BookHive.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookHive.Domain.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
