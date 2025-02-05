using BookHive.Domain.Common;
using BookHive.Domain.Enums;
using BookHive.Domain.Identity;

namespace BookHive.Domain.Entities
{
    public class Friendship : BaseEntity
    {
        public Guid RequesterId { get; set; }       
        public AppUser Requester { get; set; }        

        public Guid AddresseeId { get; set; }      
        public AppUser Addressee { get; set; }         

        public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; } 

        public bool IsBlocked { get; set; } = false;
    }
}
