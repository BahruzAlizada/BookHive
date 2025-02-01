using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class BookDiscount : BaseEntity
    {
        public Guid? BookId { get; set; } // Book ilə əlaqə
        public Book? Book { get; set; }   // Navigation property

        public Guid? GenreId { get; set; }
        public Genre? Genre { get; set; }

        public int DiscountPercentage { get; set; } // Endirim faizi
        public bool IsDiscount { get; set; } // Endirim aktivdir?
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
