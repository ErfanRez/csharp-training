using DAL.Entities;

namespace CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
