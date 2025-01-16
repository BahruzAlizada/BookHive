using BookHive.Domain.Common;

namespace BookHive.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
