using BookHive.Domain.Common;
using BookHive.Domain.Identity;

namespace BookHive.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsUsedCoupon {  get; set; }
        public DateTime? CouponUsedDate {  get; set; }
        public double TotalPrice {  get; set; }

        public Guid? CouponId { get; set; } 
        public Coupon? Coupon { get; set; }
    }
}
