using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class BookStatus : BaseEntity
    {
        public string Name { get; set; }  // Məsələn: "Bestseller", "New Release", "Recommended"
        public bool Status { get; set; } = true;

        public ICollection<Book> Books { get; set; }
    }
}
