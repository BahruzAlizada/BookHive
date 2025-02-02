using BookHive.Domain.Common;
using BookHive.Domain.Enums;

namespace BookHive.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; set; }           
        public Order Order { get; set; }

        public double Amount { get; set; }            
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow.AddHours(4);

        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public CreditCard CreditCard { get; set; }
        public string TransactionId { get; set; }     
        public string? ReceiptUrl { get; set; }
    }
}
