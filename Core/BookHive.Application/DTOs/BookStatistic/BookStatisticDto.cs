using BookHive.Domain.Entities;

namespace BookHive.Application.DTOs
{
    public class BookStatisticDto
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }

        public double AverageRating { get; set; }
        public int TotalReview { get; set; }
        public int TotalSales { get; set; }
    }
}
