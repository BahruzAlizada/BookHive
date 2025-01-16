

namespace BookHive.Application.DTOs
{
    public class GenreUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
