using BookHive.Domain.Common;
using BookHive.Domain.Identity;

namespace BookHive.Domain.Entities
{
    public class CouponUsage : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        public DateTime UsedDate { get; set; }

        public AppUser? User { get; set; }
        public Coupon? Coupon { get; set; }
    }
}
