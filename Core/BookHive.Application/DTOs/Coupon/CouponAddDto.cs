namespace BookHive.Application.DTOs
{
    public class CouponAddDto
    {
        public string Code { get; set; }
        public double Discount { get; set; }
        public bool IsPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
