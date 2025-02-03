using BookHive.Domain.Enums;

namespace BookHive.Application.DTOs
{
    public class BookDto 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Pages { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }
        public double DiscountPrice { get; set; }

        public Guid GenreId { get; set; }
        public string GenreName { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookLanguage { get; set; }
        public string? BookStatus { get; set; }
        public double AverageRating { get; set; }
        public int TotalReview { get; set; }
    }
}
