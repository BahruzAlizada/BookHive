using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name {  get; set; }
        public bool Status { get; set; } = true;

        public ICollection<Genre>? Genres { get; set; }
    }
}
