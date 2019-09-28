namespace NoSocNet.Domain.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }
        public bool Followed { get; set; }
    }
}
