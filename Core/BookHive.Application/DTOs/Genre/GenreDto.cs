

namespace BookHive.Application.DTOs
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status {  get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BookCount { get; set; }
    }
}
