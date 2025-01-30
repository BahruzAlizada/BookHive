

using BookHive.Domain.Enums;

namespace BookHive.Application.DTOs
{
    public class BookUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }

        public Guid GenreId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid AuthorId { get; set; }
        public BookLanguage BookLanguage { get; set; }
        //public BookStatus BookStatus { get; set; }
    }
}
