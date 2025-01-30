using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class BookStatistics : BaseEntity
    {
        public Guid BookId { get; set; } 
        public Book Book { get; set; }  

        public double AverageRating { get; set; }
        public int TotalReview { get; set; }
        public int TotalSales { get; set; }

    }
}
