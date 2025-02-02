

namespace BookHive.Application.DTOs
{
    public class BasketItemAddDto
    {
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}
