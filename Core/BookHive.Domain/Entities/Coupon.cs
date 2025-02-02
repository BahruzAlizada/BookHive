using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; } = null!;
        public double Discount { get; set; }
        public bool IsPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ICollection<CouponUsage> CouponUsages { get; set; }
    }
}
