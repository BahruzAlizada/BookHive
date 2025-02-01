
namespace BookHive.Application.DTOs.Review
{
    public class ReviewAddDto
    {
        public Guid UserId { get; set; }    
        public Guid BookId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
