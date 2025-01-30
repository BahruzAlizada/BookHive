using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
