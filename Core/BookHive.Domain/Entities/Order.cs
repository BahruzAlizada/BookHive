using BookHive.Domain.Common;
using BookHive.Domain.Enums;

namespace BookHive.Domain.Entities
{
    public class Order : BaseEntity
    {

        public string OrderCode { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public double TotalPrice { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }

        public bool IsCompleted { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    }
}
