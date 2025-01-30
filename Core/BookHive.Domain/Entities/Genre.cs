using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<BookDiscount> Discounts { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
