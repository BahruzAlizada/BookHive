
namespace BookHive.Application.DTOs
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool Status { get; set; } 
        public int BookCount { get; set; }
    }
}
