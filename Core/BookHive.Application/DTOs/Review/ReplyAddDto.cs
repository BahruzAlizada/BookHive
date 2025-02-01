

namespace BookHive.Application.DTOs
{
    public class ReplyAddDto
    {
        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }  
        public string Comment {  get; set; }
    }
}
