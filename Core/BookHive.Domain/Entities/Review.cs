using BookHive.Domain.Common;
using BookHive.Domain.Identity;

namespace BookHive.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public string Comment { get; set; }
        public int? Rating { get; set; }

        public Guid? ParentId { get; set; }
        public ICollection<Review>? Replies { get; set; }
        public bool IsMain { get; set; }
    }
}
