

using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<Book> Books { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
