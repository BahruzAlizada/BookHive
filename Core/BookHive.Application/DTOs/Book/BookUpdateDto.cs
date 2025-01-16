

namespace BookHive.Application.DTOs
{
    public class BookUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Pages { get; set; }

        public Guid GenreId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookLanguageId { get; set; }
        public Guid BookStatusId { get; set; }
    }
}
