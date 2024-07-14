using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [AllowNull]
        public string Fullname { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<PostComment> PostComments { get; set; }
    }

    public enum UserRole
    {
        Admin,
        User,
        Author,
    }
}
