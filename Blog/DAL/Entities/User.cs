using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities
{
    public class User : BaseEntity
    {

        [Required]
        public string Username { get; set; }

        [AllowNull]
        public string Fullname { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }


        #region Relations

        [AllowNull]
        public ICollection<Post> Posts { get; set; }

        [AllowNull]
        public ICollection<PostComment> PostComments { get; set; }

        #endregion

    }

    public enum UserRole
    {
        Admin,
        User,
        Author,
    }
}
