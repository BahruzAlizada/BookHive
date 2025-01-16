namespace BookHive.Application.DTOs
{
    public class UpdatePasswordDto
    {
        public Guid UserId { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
