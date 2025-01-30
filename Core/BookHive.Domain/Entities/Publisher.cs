
using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
