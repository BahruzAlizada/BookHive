using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN {  get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Pages { get; set; }
        public bool Status { get; set; } = true;



        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public Guid BookLanguageId { get; set; }    
        public BookLanguage BookLanguage { get; set; }

        public Guid BookStatusId {  get; set; }
        public BookStatus BookStatus { get; set; }
    }
}
