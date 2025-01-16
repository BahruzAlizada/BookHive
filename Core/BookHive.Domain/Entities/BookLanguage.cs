

using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class BookLanguage : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<Book> Books { get; set; }
    }
}
