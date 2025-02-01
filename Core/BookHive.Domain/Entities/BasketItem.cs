
using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid BookId { get; set; }

        public int Quantity { get; set; }

        public Basket? Basket { get; set; }
        public Book? Book { get; set; }
    }
}
