using BookHive.Domain.Common;
using BookHive.Domain.Enums;

namespace BookHive.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Pages { get; set; }
        public string ISBN {  get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
        public double DiscountPrice { get; set; }


        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }



        public BookLanguage BookLanguage { get; set; }
        public BookStatus? BookStatus { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public BookStatistics BookStatistics { get; set; }
        public BookDiscount BookDiscount { get; set; }
    }
}
