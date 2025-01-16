

namespace BookHive.Application.DTOs.Book
{
    public class BookDto 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Pages { get; set; }

        public Guid GenreId { get; set; }
        public string GenreName { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Guid BookLanguageId { get; set; }
        public string BookLanguageName { get; set; }
        public Guid BookStatusId { get; set; }
        public string BookStatusName { get; set; }
    }
}
